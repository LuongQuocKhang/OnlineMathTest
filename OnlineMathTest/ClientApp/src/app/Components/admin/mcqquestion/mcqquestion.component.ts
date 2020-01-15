import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../../Services/sharedService";

declare var $: any;
import 'datatables.net';
import 'datatables.net-bs4';

@Component({
  selector: 'app-mcqquestion',
  templateUrl: './mcqquestion.component.html',
  styleUrls: ['./mcqquestion.component.css']
})
export class McqQuestionComponent implements OnInit {
  public isLoaded = true;
  isInitDatatable = false;
  tableMain: any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    
  }

  ngOnInit() {
  }
  ngAfterViewInit() {
    this.getAll();
  }
  public getAll() {
    this.isLoaded = false;
    var self = this;
    if (!this.isInitDatatable) {
      var url = '/adminpage/mcqquestion';
      var table = $('#tblDatatable').dataTable({
        "processing": true,
        "serverSide": true,
        "paging": true,
        "bLengthChange": true,
        "pageLength": 10,
        "searching": false,
        "ajax": {
          "url": url,
          "type": 'POST',
          "data": function (d: any) {
            
          }
        },
        "columns": [
          { "data": "title", "orderable": false, },
          {
            "data": "isDisabled",
            "orderable": false,
            render: function (data: any, type: any, row: any) {

              var html =
                "<a class=\"btn btn-primary btn-sm\ editQuestion\" href =\"javascript:;\">" +
                  "<span class=\"fa fa-pencil\"> </span>" + 
                "</a>" + 
                "<a class=\"btn btn-danger btn-sm\ deleteQuestion\" href=\"javascript:;\" style=\"margin-left: 5px;\">" +
                  "<span class=\"fa fa-trash-o\" > </span>" +
                "</a>";
              return html;
            }
          }
        ],
        rowCallback: (row: Node, data: any | Object, index: number) => {
          $('.editQuestion', row).unbind('click');
          $('.editQuestion', row).bind('click', (e: any) => {
            e.preventDefault();
            e.stopPropagation();
            this.router.navigate(['/adminpage/mcqquestion/edit', data.id]);
          });
          $('.deleteQuestion', row).unbind('click');
          $('.deleteQuestion', row).bind('click', (e: any) => {
            e.preventDefault();
            e.stopPropagation();
            this.deleteQuestion(data);
          });
          return row;
        }
      });
      this.isInitDatatable = true;
      this.tableMain = table;
      this.isLoaded = true;
    }
    else {
      if (this.tableMain != null) {
        $('#tblDatatable').DataTable().ajax.reload();
        this.isLoaded = true;
      }
    }
  }
  public deleteQuestion(question: any) {
    this.http.post('/adminpage/mcqquestion/deleteQuestion', question)
      .subscribe((response: any) => {
        if (response.success) {
          this.sharedService.show('Xóa thành công', 'SUCCESS');
          $('#tblDatatable').DataTable().ajax.reload();
        }
        else {
          this.sharedService.show('Xảy ra lỗi khi xóa', 'ERROR');
        }
      })
  }
}
