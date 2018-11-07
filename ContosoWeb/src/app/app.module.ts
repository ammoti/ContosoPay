import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RouterModule, Routes } from '../../node_modules/@angular/router';
import { GridSellerComponent } from './grid-seller/grid-seller.component';
import { AddOrUpdateSellerComponent } from './add-or-update-seller/add-or-update-seller.component';
import { HttpClientModule } from '@angular/common/http';
import { SellersService } from './sellers.service';
import { MenuComponent } from './menu/menu.component';

const appRoutes:Routes = [{path:'',component:HomeComponent}];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GridSellerComponent,
    AddOrUpdateSellerComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [
    SellersService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
