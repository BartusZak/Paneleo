import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule, PaginationModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { MomentModule } from 'ngx-moment';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { UsersListComponent } from './users/users-list/users-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductsComponent } from './products/products.component';
import { appRoutes } from './routes';
import { LeftMenuComponent } from './left-menu/left-menu.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
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
import { AddOrderComponent } from './orders/add-order/add-order.component';

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
    OrdersComponent,
    AddOrderComponent,
    ProductsComponent,
    LeftMenuComponent,
    UserCardComponent,
    UserEditComponent,
    LastAddedClientsComponent,
    LastAddedOrdersComponent,
    LastAddedProductsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
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
    UserEditResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
