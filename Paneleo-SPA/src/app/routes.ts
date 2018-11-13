import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductsComponent } from './products/products.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { UsersListResolver } from './_resolvers/users-list-resolver';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/users-edit-resolver';

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
        path: 'products',
        component: ProductsComponent,
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
