import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './features/authentication/pages/login/login.component';

const routes: Routes = [
  { 
    path: '', 
    redirectTo: '/Login', 
    pathMatch: 'full' 
  },
  { 
    path: 'Login', 
    component: LoginComponent
  },
  {
    path: 'Home',
    loadChildren: () =>
    import('./features/dashboard/dashboard.module').then(m => m.DashboardModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }