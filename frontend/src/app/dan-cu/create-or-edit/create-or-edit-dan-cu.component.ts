import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { DanCuDto, DanCuService } from '@shared/service-proxies/service-proxies';
import { result } from 'lodash-es';

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
    constructor(
        injector: Injector,
        private _danCuService: DanCuService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    ngOnInit() {
        this.ngayDi = this.dto.ngayDi ? this.dto.ngayDi.toDate() : null;
        this.ngayDen = this.dto.ngayDen ? this.dto.ngayDen.toDate() : null;
        this.ngaySinh = this.dto.ngayDi ? this.dto.ngaySinh.toDate() : null;

        this._activatedRoute.queryParams.subscribe(params => {
            this.status = params['status'];
        });
        let id = +this._activatedRoute.snapshot.paramMap.get('id');
        if (id) {
            this.getDanCuForEdit(id);
        }

    }

    processDataBeforeSave() {
    }

    getDanCuForEdit(id) {
        this._danCuService.getForEdit(id).subscribe(result => {
            this.dto = result;
            if (this.status == 1) {
                this.dto.id = 0;
                this.dto.cmnd = null;
                this.dto.hoVaTen = null;
                this.dto.hoChieu = null;
                this.dto.ngaySinh = null;
                this.dto.hoChieu = null;
            }
        });
    }

    save() {
        try {
            this._danCuService.createOrEditDanCu(this.dto).subscribe(result => {
                if (result) {
                    this.notify.success("Thành công");
                    this._router.navigateByUrl("/app/dan-cu");
                }
            });
        } catch (error) {
            this.notify.error("Dữ liệu không hợp lệ");
        }

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
