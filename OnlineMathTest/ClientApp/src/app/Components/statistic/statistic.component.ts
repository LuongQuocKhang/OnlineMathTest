import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";

import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
declare var $: any;
import 'datatables.net';
import 'datatables.net-bs4';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {

  public isLoaded = false;
  public userTests = [] as any;
  public stastistics = {} as any;

  private sub: any;
  public userId = "";

  public barChartLabels: Label[] = [] as any;
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartData: ChartDataSets[];

  constructor(private chRef: ChangeDetectorRef,private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.sub = this.route.params.subscribe(params => {
      this.userId = params['id'];
    });
    this.getStastistics(this.userId);
    this.getAllUserTest();
  }

  ngOnInit() {
  }
  public barChartOptions: ChartOptions = {
    responsive: true,
    scales: { xAxes: [{}], yAxes: [{}] },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };
  public getAllUserTest() {
    this.http.get('/stastistic/getAllUserTest?UserId=' + this.sharedService.currentUser.id)
      .subscribe((response: any) => {
        if (response.success) {
          if ($.fn.DataTable.isDataTable('#tblDatatable')) {
            $('#tblDatatable').DataTable().clear().destroy();
          }
          this.userTests = response.data;
          for (var i = 0; i < this.userTests.length; i++) {
            this.userTests[i].point = parseFloat(this.userTests[i].point).toFixed(2);
          }
          this.chRef.detectChanges();
          this.initFormTable();
        }
      })
  }

  public getStastistics(id: any) {
    this.isLoaded = false;
    this.http.get('/stastistic/getStastistics?UserId=' + id)
      .subscribe(
        (response: any) => {
          if (response.success) {
            this.stastistics = response.data;
            var correct = { data: this.stastistics.chartCorrectAnswer, label: 'Đúng' }
            var wrong = { data: this.stastistics.chartWrongAnswer, label: 'Sai' }

            this.barChartData = [correct, wrong];
            this.barChartLabels = [...this.stastistics.type];
            this.isLoaded = true;
          }
        },
        () => { this.isLoaded = true; }
      )
  }
  public initFormTable() {
    var table = $('#tblDatatable');
    if (!$.fn.DataTable.isDataTable('#tblDatatable')) {
      table.dataTable({
        "lengthMenu": [
          [10, 20, 50, -1],
          [10, 20, 50, "All"]
        ],
        "pageLength": 10,
        "bLengthChange": false,
        "searching": false,
        "ordering": false
      });
    }
  }
  public viewDetail(userTestId: any) {
    window.location.href = 'r' + '/#/mcq/exam/result/' + userTestId;
  }
}
