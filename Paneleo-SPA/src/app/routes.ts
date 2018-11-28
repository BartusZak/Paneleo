import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { OrdersComponent } from './orders/orders.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { UsersListResolver } from './_resolvers/users-list-resolver';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/users-edit-resolver';
import { AddOrderComponent } from './orders/add-order/add-order.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductListResolver } from './_resolvers/products-list-resolver';
import { ProductAddComponent } from './products/product-add/product-add.component';
import { ContractorListComponent } from './contractors/contractor-list/contractor-list.component';
import { ContractorAddComponent } from './contractors/contractor-add/contractor-add.component';
import { ContractorListResolver } from './_resolvers/contractors-list-resolver';

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
        component: OrdersComponent,
        data: [{ title: 'Zamówienia' }]
      },
      {
        path: 'orders/add',
        component: AddOrderComponent,
        data: { title: 'Dodawanie zamówienia' }
        // resolve: { user: UserEditResolver }
      },
      {
        path: 'products',
        component: ProductListComponent,
        data: { title: 'Lista Produktów' },
        resolve: { list: ProductListResolver }
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
