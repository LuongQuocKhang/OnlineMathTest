import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../../Services/sharedService";
@Component({
  selector: 'app-mcqmanagement-edit',
  templateUrl: './mcqmanagement.edit.component.html',
  styleUrls: ['./mcqmanagement.edit.component.css']
})
export class EditMcqManagementComponent implements OnInit {

  private sub: any;
  public mcqId = 0;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.sub = this.route.params.subscribe(params => {
      this.mcqId = params['id'];
    });
  }

  ngOnInit() {
  }
  public updateMCQ(mcq: any) {
    this.http.post('/adminpage/mcq/updateMcq', mcq)
      .subscribe((response: any) => {
        if (response.success) {
          this.sharedService.show('Cập nhật thành công', 'SUCCESS');
        }
        else {
          this.sharedService.show('Cập nhật không thành công', 'ERROR');
        }
      })
  }
}
