import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { AppConsts } from '@shared/AppConsts';
import { DanCuDto, DanCuService, FileServiceProxy } from '@shared/service-proxies/service-proxies';
import { SSL_OP_LEGACY_SERVER_CONNECT } from 'constants';
import { result } from 'lodash-es';
declare var $;
@Component({
    templateUrl: 'create-or-edit-dan-cu.component.html',
    animations: [appModuleAnimation()]

})

export class CreateOrEditDanCuComponent extends AppComponentBase implements OnInit {
    dto: DanCuDto = new DanCuDto();
    ngayDi: Date;
    ngayDen: Date;
    ngaySinh: Date;
    status = 0;
    @ViewChild('avatarUploader', { static: false }) avatarUploader: any;
    avatar = [];
    dsIdAvatars: string = "";
    uploaderOptions = {
        multiple: true,
        labelIdle: "Click để thêm ảnh",
        labelFileLoading: "Đang tải ảnh",
        labelFileLoadError: "Gặp lỗi khi tải ảnh",
        labelFileProcessing: "Đang tải ảnh",
        labelFileProcessingComplete: "Tải ảnh thành công",
        labelFileProcessingError: "Gặp lỗi khi tải ảnh",
        labelTapToCancel: "Huỷ",
        labelTapToRetry: "Thử lại",
        labelTapToUndo: "Undo",
        labelButtonRemoveItem: "Xoá",
        labelButtonAbortItemLoad: "Huỷ",
        acceptedFileTypes: 'image/jpeg, image/png, image/jpg',
        credits: false,
        allowImagePreview: true
    }

    constructor(
        injector: Injector,
        private _danCuService: DanCuService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _fileAppService: FileServiceProxy

    ) {
        super(injector);
    }
    deactiveNhomMau(event) {
        console.log(event);
        if (event.srcElement.attributes.val && this.dto.nhomMau == +event.srcElement.attributes.val.value) {
            this.dto.nhomMau = null;
        }
    }
    ngOnInit() {


        this._activatedRoute.queryParams.subscribe(params => {
            this.status = params['status'];
        });
        let id = +this._activatedRoute.snapshot.paramMap.get('id');
        if (id) {
            this.getDanCuForEdit(id);
        } else {
            this.dto.danToc = "Kinh";
            this.dto.tonGiao = "Không";
            this.dto.quocTich = "Việt Nam";
        }


    }


    pondHandleAddFile(event: any) {
        // let self = this;
        // let formData = new FormData();
        // formData.append("file", event.file.file);
        // this._fileAppService.uploadFile(formData).subscribe(result => {
        //     if (result.id == -1) {
        //         this.avatarUploader.removeFile();
        //         this.notify.error("Lỗi khi tải file", "Lỗi", {
        //             "showDuration": "3000",
        //         });
        //     } else {
        //         self.dto.idAvatar = result.id;
        //     }
        // });
    }


    processDataBeforeSave() {
    }

    getDanCuForEdit(id) {
        this._danCuService.getForEdit(id).subscribe(result => {
            this.dto = result;
            console.log(this.dto.ngaySinh);

            this.ngayDi = this.dto.ngayDi ? this.dto.ngayDi.toDate() : null;
            this.ngayDen = this.dto.ngayDen ? this.dto.ngayDen.toDate() : null;
            this.ngaySinh = this.dto.ngaySinh ? this.dto.ngaySinh.toDate() : null;


            console.log(this.ngaySinh);

            if (this.status == 1) {
                this.dto.id = 0;
                this.dto.cmnd = null;
                this.dto.hoVaTen = null;
                this.dto.hoChieu = null;
                this.dto.ngaySinh = null;
                this.dto.hoChieu = null;
                this.avatarUploader.removeFiles();
            } else {
                this.dto.avatars.forEach(avatar => {
                    this.avatarUploader.addFile(AppConsts.remoteServiceBaseUrl + avatar.url);
                });
            }
        });
    }


    pondHandleRemoveFile(event) {
        console.log(event);
        // this.avatarUploader.removeFile(event.file.id);
        // this.dto.idAvatar = null;
    }

    save() {

        let self = this;
        let formData = new FormData();
        this.avatarUploader.getFiles().map(m => {
            formData.append("files", m.file, m.file.name);
        });
        this._fileAppService.uploadFiles(formData).subscribe(result => {
            self.dto.idAvatars = result;
            try {
                self._danCuService.createOrEditDanCu(this.dto).subscribe(result => {
                    if (result) {
                        self.notify.success("Thành công");
                        self._router.navigateByUrl("/app/dan-cu");
                    }
                });
            } catch (error) {
                self.notify.error("Dữ liệu không hợp lệ");
            }
        });
    }

    changeDanToc(event) {
        if (this.dto.danToc) {
            this.dto.danToc = "Kinh";
        } else {
            this.dto.danToc = null;
        }

    }

    changeTonGiao(event) {
        if (this.dto.tonGiao) {
            this.dto.tonGiao = "Không";
        } else {
            this.dto.tonGiao = null;
        }

    }


    changeQuocTich(event) {
        if (this.dto.quocTich) {
            this.dto.quocTich = "Việt Nam";
        } else {
            this.dto.quocTich = null;
        }

    }

    changeHocVan(event) {
        if (this.dto.hocVan) {
            this.dto.hocVan = "Đại học";
        } else {
            this.dto.hocVan = null;
        }

    }
}
