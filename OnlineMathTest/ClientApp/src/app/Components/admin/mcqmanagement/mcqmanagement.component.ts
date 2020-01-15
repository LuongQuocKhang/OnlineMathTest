import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../../Services/sharedService";

declare var $: any;
import 'datatables.net';
import 'datatables.net-bs4';

@Component({
  selector: 'app-mcqmanagement',
  templateUrl: './mcqmanagement.component.html',
  styleUrls: ['./mcqmanagement.component.css']
})
export class McqManagementComponent implements OnInit {
  public mcqs = [] as any;
  constructor(private chRef: ChangeDetectorRef,private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.getAllMCQ();
  }

  ngOnInit() {
  }
  public getAllMCQ() {
    this.http.get('/adminpage/mcq/getAllMCQ')
      .subscribe((response: any) => {
        this.mcqs = response.data;

        if ($.fn.DataTable.isDataTable('#tblDatatable')) {
          $('#tblDatatable').DataTable().clear().destroy();
        }
        this.mcqs = response.data;
        this.chRef.detectChanges();
        this.initFormTable();
      })
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
}
