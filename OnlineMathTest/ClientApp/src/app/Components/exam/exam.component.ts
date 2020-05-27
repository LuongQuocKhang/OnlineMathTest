import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";
import Swal from 'sweetalert2'

declare var $: any;
@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css']
})
export class ExamComponent implements OnInit {
  private sub: any;
  public model = {} as any;
  public mcqId = 0 as any;
  public isEnd = false;
  public config = {} as any;
  public isLoaded = false;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.sub = this.route.params.subscribe(params => {
      this.mcqId = params['id'];
    });
    this.getMCQById();
  }

  ngOnInit() {
    
  }
  public getMCQById() {
    this.isLoaded = false;
    this.http.get('/MCQ/GetMCQById?id=' + this.mcqId).subscribe(
      (response: any) => {
        this.model = response.data;
        this.config = { leftTime: this.model.duration * 60 };
        this.isLoaded = true;
      })
  }
  ngAfterViewInt() {

  }
  public submitExam() {
    Swal.fire(
      {
        title: "Bạn có chắc muốn nộp bài không ?",
        icon: 'question', 
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Nộp',
        cancelButtonText: 'Không'
      }).then((result) => {
        if (result.value) {
          this.http.post('/mcq/submitExam', this.model)
            .subscribe((response: any) => {
              if (response.success) {
                Swal.fire(
                  'Good job!',
                  'Nộp bài thành công',
                  'success'
                )
                window.location.href = 'r' + '/#/mcq/exam/result/' + response.data;
              }
              else {
                this.sharedService.show('Nộp bài không thành công', 'ERRO');
              }
            })
        }
      })
  }
  public handleEvent(event) {
    let timeLeft = event.left;
    if (timeLeft == 0) {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Hết thời gian làm bài!',
      })
      this.isEnd = true;
    }
  }
}
