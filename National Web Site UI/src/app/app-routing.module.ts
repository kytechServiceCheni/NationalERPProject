import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './homepage/admin/admin.component';
import { HeaderComponent } from './homepage/header/header.component';
import { HomeComponent } from './homepage/home/home.component';
import { LoginComponent } from './homepage/login/login.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'login_page',component:LoginComponent},
  {path:'admin_page',component:AdminComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
