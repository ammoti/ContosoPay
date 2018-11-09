import { Component, OnInit } from "@angular/core";
import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";
import { SellerService } from "../services/seller.service";
import * as _ from "lodash";
@Component({
  selector: "app-seller",
  templateUrl: "./seller.component.html",
  styleUrls: ["./seller.component.css"]
})
export class SellerComponent implements OnInit {
  sellers: Sellers[] = [];
  selModel: Sellers;
  showNew: Boolean = false;
  submitType: string = "Save";
  selectedRow: any;

  constructor(private sellerService: SellerService) {
    sellerService.get().subscribe((data: any) => (this.sellers = data));
  }

  ngOnInit() {}
  onNew() {
    this.selModel = new Sellers();
    this.submitType = "Save";
    this.showNew = true;
  }
  onSave() {
    if (this.submitType === "Save") {
      this.sellerService.add(this.selModel).subscribe(selRecord=>this.sellers.push(this.selModel));
    } else {    
      this.sellerService.update(this.selModel).subscribe(response=>{})
      const updateIndex = _.findIndex(this.sellers, {id: this.selectedRow.id});
      this.sellers[updateIndex].name = this.selModel.name;
      this.sellers[updateIndex].minRange = this.selModel.minRange;
      this.sellers[updateIndex].maxRange = this.selModel.maxRange;
    }
    // Hide registration entry section.
    this.showNew = false;
  }
  // This method associate to Edit Button.
  onEdit(index: number) {
    // Assign selected table row index.
    this.selectedRow = _.find(this.sellers,(el=>el.id === index));
    const updateIndex = _.findIndex(this.sellers, {id: this.selectedRow.id});
    // Initiate new registration.
    this.selModel = new Sellers();
    this.selModel = Object.assign({}, this.sellers[updateIndex]);
    // Change submitType to Update.
    this.submitType = "Update";
    this.showNew = true;
  }
  onDelete(index: number) {
    this.selectedRow = _.find(this.sellers,(el=>el.id === index));
    const updateIndex = _.findIndex(this.sellers, {id: this.selectedRow.id});
    this.selModel=this.sellers[updateIndex];
    this.sellers.splice(updateIndex, 1);
    this.sellerService.remove(this.selModel).subscribe(response=>{});
  }
  onCancel() {
    this.showNew = false;
  }
}
export class Sellers {
  constructor(
    public id:Number=0,
    public name: string = "",
    public minRange: number = 0,
    public maxRange: number = 0,
    public createDate:Date=new Date(),
    public updateDate:Date=new Date(),
    public isActive:Boolean=true,
    public isDeleted:Boolean=false
  ) {}
}
