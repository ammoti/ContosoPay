import { Component,Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-seller',
  templateUrl: './grid-seller.component.html',
  styleUrls: ['./grid-seller.component.css']
})
export class GridSellerComponent implements OnInit {

  @Input() sellerData:Array<any>;
  constructor() { }

  ngOnInit() {
  }

}
