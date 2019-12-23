import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
@Component({
  selector: 'app-list-mcq',
  templateUrl: './list-mcq.component.html',
  styleUrls: ['./list-mcq.component.css']
})
export class ListMcqComponent implements OnInit {
  public model = {} as any;
  private sub: any;
  constructor(private router: Router, private route: ActivatedRoute) {
   
  }
 
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.model.id = params['id'];
    });
  }
  public viewDetail(item: any) {
    this.router.navigate(['/mcqdetail/', item.id]);
  }
}
