import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-mcq-detail',
  templateUrl: './mcq-detail.component.html',
  styleUrls: ['./mcq-detail.component.css']
})
export class McqDetailComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

}
