import { NgModule } from '@angular/core';
import { ModuleShared } from '../Modules/module.shared';
import { ListMcqComponent } from '../Components/list-mcq/list-mcq.component';
import { McqDetailComponent } from '../Components/list-mcq/mcq-detail.component';
import { RouterModule } from '@angular/router';
import { MathJaxModule } from './math-jax.module';
import { ExamComponent } from '../Components/exam/exam.component';
import { AuthGuardService } from '../Services/AuthGuardService';

import { MathJaxService } from '../Services/math-jax.service';
@NgModule({
  declarations: [
    McqDetailComponent,
    ListMcqComponent
  ],
  imports: [
    ModuleShared,
    RouterModule.forRoot([
      { path: 'mcqdetail/:id', component: McqDetailComponent },
      { path: 'listmcq', component: ListMcqComponent },
      { path: 'exam/:id', component: ExamComponent, canActivate: [AuthGuardService] },
    ]),
    MathJaxModule.forRoot({
      version: '2.7.5',
      config: 'TeX-AMS_HTML',
      hostname: 'cdnjs.cloudflare.com'
    }),
  ],
  providers: [
    AuthGuardService,
    MathJaxService,
  ],
})
export class MCQModule {

}
