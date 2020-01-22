import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
declare var $: any;
declare var moment: any;
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public Exam = {
    startDate: new Date(),
    endDate: new Date()
  };
  ranges: any = {
    'Today': [moment(), moment()],
    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
    'This Month': [moment().startOf('month'), moment().endOf('month')],
    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
  }
  public locale = {
    format: 'DD/MM/YYYY',
    direction: 'ltr', // could be rtl
    weekLabel: 'W',
    separator: ' - ', // default is ' - '
    cancelLabel: 'Cancel', // detault is 'Cancel'
    applyLabel: 'Xem', // detault is 'Apply'
    clearLabel: 'Clear', // detault is 'Clear'
    customRangeLabel: 'Custom range',
    daysOfWeek: moment.weekdaysMin(),
    monthNames: moment.monthsShort(),
    firstDay: 1 // first day is monday
  };
  public barChartOptions: ChartOptions = {
    responsive: true,
    // We use these empty structures as placeholders for dynamic theming.
    scales: { xAxes: [{}], yAxes: [{}] },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };
  public barChartLabels: Label[] = [] as any;
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartData: ChartDataSets[];

  public isLoaded = false;
  public chart = {} as any;
  public report = {} as any;

  constructor(private http: HttpClient) {
    this.getDashboardReport();
  }

  ngOnInit() {
    var today = new Date();
    this.Exam.startDate.setDate(today.getDate() - 7);
    this.Exam.endDate = today;
  }
  ngAfterViewInit() {
    this.getAllUserTest();
  }
  public getAllUserTest() {
    this.isLoaded = false;

    var dataPost = {} as any;
    dataPost.startDate = this.Exam.startDate != null ? moment(this.Exam.startDate).format('MM-DD-YYYY') : null;
    dataPost.endDate = this.Exam.endDate != null ? moment(this.Exam.endDate).format('MM-DD-YYYY') : null;

    this.http.get('/dashboard/getAllUserTest?startDate=' + dataPost.startDate + '&endDate=' + dataPost.endDate)
      .subscribe((response: any) => {
        if (response.success) {
          this.chart = response.data;
          this.barChartLabels = [...this.chart.dates];
          let attemps = [{ data: this.chart.attemps, label: "Lượt thi" }];
          this.barChartData = [...attemps];
        }
        this.isLoaded = true;
      })
  }

  public getDashboardReport() {
    this.http.get('/dashboard/getDashboardReport')
      .subscribe(
        (response: any) => {
          if (response.success) {
            this.report = response.data;
          }
      })
  }
}
