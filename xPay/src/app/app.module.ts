import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { FormsModule } from '@angular/forms';
import { SellerComponent } from './seller/seller.component';

import { SellerService } from "./services/seller.service";
import{ ActionService} from "./services/action.service";
import { ReportService } from "./services/report.service";
import { HttpClientModule } from "@angular/common/http";
import { ActionComponent } from './action/action.component';
import { ReportComponent } from './report/report.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    RegistrationComponent,
    SellerComponent,
    ActionComponent,
    ReportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule.forRoot(),
    FormsModule,
    HttpClientModule
  ],
  providers: [SellerService,ActionService,ReportService],
  bootstrap: [AppComponent]
})
export class AppModule { }
