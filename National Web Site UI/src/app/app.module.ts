import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './homepage/home/home.component';
import { HeaderComponent } from './homepage/header/header.component';
import { LoginComponent } from './homepage/login/login.component';
import { AdminComponent } from './homepage/admin/admin.component';
//import { SharedModule, PanelModule } from 'primeng/primeng';
import { TreeModule } from 'primeng/tree';
import { ButtonModule } from 'primeng/button';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    LoginComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    TreeModule,
    ButtonModule
    //PanelModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
