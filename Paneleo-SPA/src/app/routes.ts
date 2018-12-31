import { ProductDetailsComponent } from './products/product-details/product-details.component';
import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { UsersListResolver } from './_resolvers/users-list-resolver';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/users-edit-resolver';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductListResolver } from './_resolvers/products-list-resolver';
import { ProductAddComponent } from './products/product-add/product-add.component';
import { ContractorListComponent } from './contractors/contractor-list/contractor-list.component';
import { ContractorAddComponent } from './contractors/contractor-add/contractor-add.component';
import { ContractorListResolver } from './_resolvers/contractors-list-resolver';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { OrderAddComponent } from './orders/order-add/order-add.component';
import { OrderListResolver } from './_resolvers/orders-list-resolver';
import { OrderAddResolver } from './_resolvers/order-add-resolver';
import { OrderDetailsComponent } from './orders/order-details/order-details.component';
import { OrderDetailsResolver } from './_resolvers/order/order-details-resolver';
import { ContractorDetailsComponent } from './contractors/contractor-details/contractor-details.component';
import { ContractorDetailsResolver } from './_resolvers/contractor/contractor-details-resolver';
import { ProductDetailsResolver } from './_resolvers/product/product-details-resolver';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        data: { title: 'Dashboard' }
      },
      {
        path: 'orders',
        component: OrderListComponent,
        data: { title: 'Zamówienia' },
        resolve: { list: OrderListResolver }
      },
      {
        path: 'orders/:id',
        component: OrderDetailsComponent,
        data: { title: 'Szczegóły zamówienia' },
        resolve: { order: OrderDetailsResolver }
      },
      {
        path: 'orders/add',
        component: OrderAddComponent,
        data: { title: 'Dodawanie zamówienia' },
        resolve: { order: OrderAddResolver }
      },
      {
        path: 'products',
        component: ProductListComponent,
        data: { title: 'Lista Produktów' },
        resolve: { list: ProductListResolver }
      },
      {
        path: 'products/:id',
        component: ProductDetailsComponent,
        data: { title: 'Szczegóły produktu' },
        resolve: { product: ProductDetailsResolver }
      },
      {
        path: 'products/add',
        component: ProductAddComponent,
        data: { title: 'Dodawanie produktu' }
      },
      {
        path: 'contractors',
        component: ContractorListComponent,
        data: { title: 'Lista Kontrahentów' },
        resolve: { list: ContractorListResolver }
      },
      {
        path: 'contractors/:id',
        component: ContractorDetailsComponent,
        data: { title: 'Szczegóły kontrahenta' },
        resolve: { contractor: ContractorDetailsResolver }
      },
      {
        path: 'contractors/add',
        component: ContractorAddComponent,
        data: { title: 'Dodawanie Kontrahenta' }
      },
      {
        path: 'users',
        component: UsersListComponent,
        data: { title: 'Użytkownicy' },
        resolve: { users: UsersListResolver }
      },
      {
        path: 'user/edit',
        component: UserEditComponent,
        data: { title: 'Edycja Profilu' },
        resolve: { user: UserEditResolver }
      }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
