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
import { ProductListResolver } from './_resolvers/products/products-list-resolver';
import { ProductAddComponent } from './products/product-add/product-add.component';

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
        data: { title: 'dashboard' }
      },
      {
        path: 'orders',
        component: OrdersComponent,
        data: [{ title: 'orders' }]
      },
      {
        path: 'orders/add',
        component: AddOrderComponent,
        data: { title: 'orders/add' }
        // resolve: { user: UserEditResolver }
      },
      {
        path: 'products',
        component: ProductListComponent,
        data: { title: 'orders' },
        resolve: { products: ProductListResolver }
      },
      {
        path: 'products/add',
        component: ProductAddComponent,
        data: { title: 'orders' }
      },
      {
        path: 'users',
        component: UsersListComponent,
        data: { title: 'users' },
        resolve: { users: UsersListResolver }
      },
      {
        path: 'user/edit',
        component: UserEditComponent,
        data: { title: 'user/edit' },
        resolve: { user: UserEditResolver }
      }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
