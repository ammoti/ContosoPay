import { Component, OnInit } from '@angular/core';
import { SellersService } from "../sellers.service";
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public sellerData: Array<any>;
  public currentSeller:any;

  constructor(private sellersService:SellersService) {
    sellersService.get().subscribe((data:any)=>this.sellerData=data);
   }

  ngOnInit() {
  }

}
