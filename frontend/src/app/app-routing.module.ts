import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { DanCuComponent } from './dan-cu/dan-cu.component';
import { CreateOrEditDanCuComponent } from './dan-cu/create-or-edit/create-or-edit-dan-cu.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent, canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'dan-cu', component: DanCuComponent, data: { permission: 'Bussiness.DanCu.Permission' }, canActivate: [AppRouteGuard] },
                    { path: 'create-or-edit-dan-cu', component: CreateOrEditDanCuComponent, data: { permission: 'Bussiness.DanCu.Permission.Create' }, canActivate: [AppRouteGuard] },
                    { path: 'create-or-edit-dan-cu/:id', component: CreateOrEditDanCuComponent, data: { permission: 'Bussiness.DanCu.Permission.Create' }, canActivate: [AppRouteGuard] }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
