import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";

import { RegistrationComponent } from "./registration/registration.component";
import { SellerComponent } from "./seller/seller.component";
import { ActionComponent } from "./action/action.component";
import { ReportComponent } from "./report/report.component";
const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },  
  {
    path: "seller",
    component: SellerComponent
  },
  {
    path:"action",
    component:ActionComponent
  },
  {
    path:"report",
    component:ReportComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
