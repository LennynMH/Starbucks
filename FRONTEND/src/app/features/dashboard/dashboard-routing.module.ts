import { RouterModule, Routes } from '@angular/router';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { AuthorizationGuard } from '../authentication/guards/auth.guard';
import { DashboardComponent } from './dashboard.component';
import { UsuarioComponent } from 'src/app/components/usuario/usuario.component';
import { RolesComponent } from 'src/app/components/roles/roles.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from 'src/app/features/authentication/guards/auth.intercetor';

const routes: Routes = [
  {
    path: '', component: DashboardComponent, canActivate: [AuthorizationGuard],
    children: [
      { path: 'Usuario', component: UsuarioComponent, canActivate: [AuthorizationGuard] },
      { path: 'Roles', component: RolesComponent, canActivate: [AuthorizationGuard] },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [
    AuthorizationGuard
    //,{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
})
export class DashboardRoutingModule { }
