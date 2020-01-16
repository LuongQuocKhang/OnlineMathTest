import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../../Services/sharedService";

declare var $: any;
import 'datatables.net';
import 'datatables.net-bs4';

@Component({
  selector: 'app-mcqmanagement-add',
  templateUrl: './mcqmanagement.add.component.html',
  styleUrls: ['./mcqmanagement.add.component.css']
})
export class AddMcqManagementComponent implements OnInit {

  public mcq = {} as any;
  public levels = [] as any;
  public mcqquestions = [] as any;
  public questions = [] as any;
  public isLoaded = false;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private sharedService: SharedService,
    private chRef: ChangeDetectorRef) {
    this.getAllLevel();
   
  }

  ngAfterViewInit() {
    this.getAllQuestion();
  }

  ngOnInit() {
  }
  public getAllLevel() {
    this.http.get('/adminpage/mcqquestion/getAllLevel')
      .subscribe((response: any) => {
        if (response.success) {
          this.levels = response.data;
        }
      })
  }
  public getAllQuestion() {
    this.http.get('/adminpage/mcqquestion/getAllQuestion')
      .subscribe((response: any) => {
        if (response.success) {
          if ($.fn.DataTable.isDataTable('#documentAddTable')) {
            $('#documentAddTable').DataTable().clear().destroy();
          }
          this.questions = response.data;
          this.chRef.detectChanges();
          this.initFormTable();
        }
      })
  }

  public onChecked(item: any) {
    item.isSelected = true;
  }
  public initFormTable() {
    var table = $('#documentAddTable');
    if (!$.fn.DataTable.isDataTable('#documentAddTable')) {
      table.dataTable({
        "lengthMenu": [
          [10, 20, 50, -1],
          [10, 20, 50, "All"]
        ],
        "pageLength": 5,
        "bLengthChange": false,
        "searching": true,
        "ordering": false
      });
    }
  }
  public addQuestion() {
    $("#AddQuestionModal").modal("show");
  }
  public addQuestionToList() {
    this.mcqquestions = [] as any;
    let length = this.questions.length;
    for (var i = 0; i < length; i++) {
      if (this.questions[i].isSelected) {
        this.mcqquestions.push(this.questions[i]);
      }
    }

    this.mcq.questions = this.mcqquestions;
  }

  public saveMcq() {
    if (this.mcq.questions.length > this.mcq.numberOfQuestion) {
      this.sharedService.show("Số lượng câu hỏi nhiều hơn số lượng câu hỏi quy định của đề thi", 'ERROR');
    }
    this.http.post('/adminpage/mcq/addmcq', this.mcq)
      .subscribe((response: any) => {
        if (response.success) {
          this.sharedService.show('Thêm đề thi thành công', 'SUCCESS');
          this.router.navigate(['/adminpage/mcq'])
        }
        else {
          this.sharedService.show('Thêm đề thi không thành công', 'ERROR');
        }
      })
  }
}
