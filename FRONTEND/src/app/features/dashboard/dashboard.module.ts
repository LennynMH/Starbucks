import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

//Angular Material
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatBadgeModule } from '@angular/material/badge';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { DashboardComponent } from './dashboard.component';
import { NavbarComponent } from 'src/app/components/navbar/navbar.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

import { ModalComponent } from 'src/app/components/modal/modal.component';
import { UsuarioComponent } from 'src/app/components/usuario/usuario.component';
import { UsuarioPopupComponent } from 'src/app/components/usuario/usuario-popup/usuario-popup.component';
import { RolesComponent } from 'src/app/components/roles/roles.component';
import { RolesPopupComponent } from 'src/app/components/roles/roles-popup/roles-popup.component';
import { ItemsComponent } from 'src/app/components/items/items.component';
import { AuthInterceptor } from 'src/app/features/authentication/guards/auth.intercetor';

@NgModule({
  declarations: [
    DashboardComponent,
    UsuarioComponent,
    UsuarioPopupComponent,
    RolesComponent,
    RolesPopupComponent,
    ItemsComponent,
    ModalComponent,

    NavbarComponent
  ],
  imports: [
    HttpClientModule,
    DashboardRoutingModule,
    CommonModule,
    MatToolbarModule,
    MatBadgeModule,
    MatIconModule,
    MatSidenavModule,
    MatButtonModule,
    MatSlideToggleModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  exports: [ModalComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
  bootstrap: [DashboardComponent]
})
export class DashboardModule { }
