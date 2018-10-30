import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsersListComponent } from './users-list/users-list.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductsComponent } from './products/products.component';

export const appRoutes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'user-list', component: UsersListComponent },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];
