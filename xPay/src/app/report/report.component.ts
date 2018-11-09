import { Component, OnInit } from "@angular/core";
import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";
import { ReportService } from "../services/report.service";
import * as _ from "lodash";

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  reports: Report[] = [];
  repModel: Report;
  
  constructor(private reportService: ReportService) {
    reportService.get().subscribe((data: any) => (this.reports = data));
  }
  ngOnInit() {
  }
}
export class Report {
  constructor(
    public id:Number=0,
    public sellerName: string = "",
    public discount:Number=0
  ) {}
}