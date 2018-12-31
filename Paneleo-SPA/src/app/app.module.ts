import { ContractorDetailsResolver } from './_resolvers/contractor/contractor-details-resolver';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule, PaginationModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { MomentModule } from 'ngx-moment';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { UsersListComponent } from './users/users-list/users-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { appRoutes } from './routes';
import { LeftMenuComponent } from './left-menu/left-menu.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/User/user.service';
import { UserCardComponent } from './users/user-card/user-card.component';
import { UsersListResolver } from './_resolvers/users-list-resolver';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/users-edit-resolver';
import { TitleService } from './_services/title.service';
import { StatsComponent } from './dashboard/stats/stats.component';
import { BoxComponent } from './dashboard/stats/box/box.component';
import { LastAddedClientsComponent } from './dashboard/last-added-clients/last-added-clients.component';
import { LastAddedOrdersComponent } from './dashboard/last-added-orders/last-added-orders.component';
import { LastAddedProductsComponent } from './dashboard/last-added-products/last-added-products.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductAddComponent } from './products/product-add/product-add.component';
import { ProductService } from './_services/Product/product.service';
import { ProductListResolver } from './_resolvers/products-list-resolver';
import { ContractorAddComponent } from './contractors/contractor-add/contractor-add.component';
import { ContractorListComponent } from './contractors/contractor-list/contractor-list.component';
import { ContractorListResolver } from './_resolvers/contractors-list-resolver';
import { DynamicFormComponent } from './_utilis/dynamic-form/dynamic-form.component';
import { DynamicFieldDirective } from './_utilis/dynamic-form/dynamic-field/dynamic-field.directive';
import { CheckboxComponent } from './_utilis/dynamic-form/checkbox/checkbox.component';
import { RadiobuttonComponent } from './_utilis/dynamic-form/radiobutton/radiobutton.component';
import { DateComponent } from './_utilis/dynamic-form/date/date.component';
import { SelectComponent } from './_utilis/dynamic-form/select/select.component';
import { ButtonComponent } from './_utilis/dynamic-form/button/button.component';
import { InputComponent } from './_utilis/dynamic-form/input/input.component';
import { GenericListComponent } from './_utilis/generic-list/generic-list.component';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { OrderAddComponent } from './orders/order-add/order-add.component';
import { OrderListResolver } from './_resolvers/orders-list-resolver';
import { ProductsComponent } from './_utilis/dynamic-form/products/products.component';
import { NipComponent } from './_utilis/dynamic-form/nip/nip.component';
import { OrderAddResolver } from './_resolvers/order-add-resolver';
import { ContractorComponent } from './_utilis/dynamic-form/contractor/contractor.component';
import { OrderDetailsComponent } from './orders/order-details/order-details.component';
import { ContractorDetailsComponent } from './contractors/contractor-details/contractor-details.component';
import { OrderDetailsResolver } from './_resolvers/order/order-details-resolver';

registerLocaleData(localePl);

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    UsersListComponent,
    DashboardComponent,
    StatsComponent,
    BoxComponent,
    OrderListComponent,
    OrderAddComponent,
    LeftMenuComponent,
    UserCardComponent,
    UserEditComponent,
    LastAddedClientsComponent,
    LastAddedOrdersComponent,
    LastAddedProductsComponent,
    ProductListComponent,
    ProductAddComponent,
    GenericListComponent,
    ContractorAddComponent,
    ContractorListComponent,
    InputComponent,
    ButtonComponent,
    SelectComponent,
    DateComponent,
    RadiobuttonComponent,
    CheckboxComponent,
    DynamicFieldDirective,
    DynamicFormComponent,
    ProductsComponent,
    NipComponent,
    ContractorComponent,
    OrderDetailsComponent,
    ContractorDetailsComponent
  ],
  imports: [
    NgxDatatableModule,
    NgbTypeaheadModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    PaginationModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:500/api/auth']
      }
    }),
    MomentModule
  ],
  providers: [
    AuthService,
    TitleService,
    ErrorInterceptorProvider,
    AlertifyService,
    AuthGuard,
    UserService,
    UsersListResolver,
    UserEditResolver,
    ProductService,
    ProductListResolver,
    ContractorListResolver,
    OrderListResolver,
    OrderAddResolver,
    OrderDetailsResolver,
    ContractorDetailsResolver,
    { provide: LOCALE_ID, useValue: 'pl' }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    InputComponent,
    ButtonComponent,
    SelectComponent,
    DateComponent,
    RadiobuttonComponent,
    CheckboxComponent,
    ProductsComponent,
    NipComponent,
    ContractorComponent
  ]
})
export class AppModule {
  constructor(titleService: TitleService) {
    titleService.init();
  }
}
