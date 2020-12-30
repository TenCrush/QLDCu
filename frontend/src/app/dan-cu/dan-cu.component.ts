import { Component, Injector, OnInit } from '@angular/core';
import { NumberValueAccessor } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ResetPasswordDialogComponent } from '@app/users/reset-password/reset-password.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { UserDto, UserServiceProxy, UserDtoPagedResultDto, DanCuDto, DanCuService, DanCuDtoResultDto } from '@shared/service-proxies/service-proxies';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
    templateUrl: 'dan-cu.component.html',
    animations: [appModuleAnimation()]
})
export class DanCuComponent extends AppComponentBase implements OnInit {
    danCus: DanCuDto[] = [];
    filterText = '';
    hasTaTS: boolean | null;
    gender : number | null;
    loaiKT : number | null;

    isTableLoading = false;

    constructor(
        injector: Injector,
        private _danCuService: DanCuService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }
    ngOnInit() {
        this.getDataPage();
    }


    getDataPage(event?: any) {
        console.log(event);
        this.isTableLoading = true;
        this._danCuService.getAllForView(this.filterText, this.gender, this.loaiKT).subscribe(m => {
            this.isTableLoading = false;
            this.danCus = m.items;
        });
    }

    create() {
        this._router.navigate(['..', 'create-or-edit-dan-cu'], { relativeTo: this._activatedRoute });
    }

    edit(entity: DanCuDto) {
        this._router.navigate(["..", "create-or-edit-dan-cu", `${entity.id}`], { relativeTo: this._activatedRoute });
    }

    duplicate(entity: DanCuDto) {
        this._router.navigateByUrl(`/app/create-or-edit-dan-cu/${entity.id}?status=1`);
    }

    delete(entity: DanCuDto) {
        let self = this;
        abp.message.confirm(
            `Xóa ${entity.hoVaTen}?`,
            "Bạn có chắc chắn?",
            (result: boolean) => {
                if (result) {
                    this._danCuService.delete(entity.id).subscribe(result => {
                        self.notify.success("Thành công");
                        self.getDataPage();
                    });
                }
            }
        );
    }
}
