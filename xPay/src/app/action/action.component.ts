import { Component, OnInit } from '@angular/core';
import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";
import { SellerService } from "../services/seller.service";
import * as _ from "lodash";
import {SellerComponent,Sellers} from "../seller/seller.component";
import { ActionService } from '../services/action.service';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  styleUrls: ['./action.component.css']
})
export class ActionComponent implements OnInit {
  operationTypes:any = [{id:1,name:"Sale"},{id:2,name:"CardInitiate"}]
  sellers: Sellers[] = [];
  operations: Action[] = [];
  opeModels:Action;
  showNew: Boolean = false;
  submitType: string = "Save";
  selectedRow: any;
  constructor(private sellerService: SellerService,private actionService:ActionService) {
    sellerService.get().subscribe((data: any) => (this.sellers = data));
    actionService.get().subscribe((data: any) => (this.operations = data));    
  }
  ngOnInit() {
  }
  onNew() {
    this.opeModels = new Action();
    this.submitType = "Save";
    // display registration entry section.
    this.showNew = true;
  }
  // This method associate to Save Button.
  onSave() {
    if (this.submitType === "Save") {
      this.actionService.add(this.opeModels).subscribe(selRecord=>this.operations.push(this.opeModels));
    } else {   
      this.actionService.update(this.opeModels).subscribe(response=>{})
      const updateIndex = _.findIndex(this.sellers, {id: this.selectedRow.id});
      this.operations[updateIndex].sellerId = this.opeModels.sellerId;
      this.operations[updateIndex].discount = this.opeModels.discount;
      this.operations[updateIndex].operationType = this.opeModels.operationType;
    }
    // Hide registration entry section.
    this.showNew = false;
  }
  // This method associate to Edit Button.
  onEdit(index: number) {
    // Assign selected table row index.
    this.selectedRow = _.find(this.operations,(el=>el.id === index));
    const updateIndex = _.findIndex(this.operations, {id: this.selectedRow.id});
    // Initiate new registration.
    this.opeModels = new Action();
    this.opeModels = Object.assign({}, this.operations[updateIndex]);
    // Change submitType to Update.
    this.submitType = "Update";
    this.showNew = true;
  }
  // This method associate to Delete Button.
  onDelete(index: number) {
    this.selectedRow = _.find(this.operations,(el=>el.id === index));
    const updateIndex = _.findIndex(this.operations, {id: this.selectedRow.id});
    this.opeModels=this.operations[updateIndex];
 this.actionService.remove(this.opeModels).subscribe(response=>{});
 this.operations.splice(updateIndex, 1);
   
  }
  // This method associate to Cancel Button.
  onCancel() {
    this.showNew = false;
  }
  onChangeSeller(seller: Number,itemName:string) {
    this.opeModels.sellerId = seller;
    this.opeModels.sellerName=itemName;
    } 
    onChangeOperationType(id: Number,itemName:string) {
      this.opeModels.operationType = id;
      this.opeModels.typeName=itemName;
      }
}


class Action {
  constructor(
    public id:Number=0,
    public createDate:Date=new Date(),
    public updateDate:Date=new Date(),
    public isActive:Boolean=true,
    public isDeleted:Boolean=false,
    public discount:Number=0,
    public sellerId:Number=0,
    public operationType:Number=2,
    public typeName:string='CardInitiate',
    public sellerName:string=''
  ) {}
}