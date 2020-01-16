import { NgModule } from '@angular/core';
import { ModuleShared } from '../Modules/module.shared';
import { ListMcqComponent } from '../Components/list-mcq/list-mcq.component';
import { McqDetailComponent } from '../Components/list-mcq/mcq-detail.component';
import { RouterModule } from '@angular/router';
import { ExamComponent } from '../Components/exam/exam.component';
import { AuthGuardService } from '../Services/AuthGuardService';
import { ExamResultComponent } from '../Components/exam/exam.result.component';
import { MathJaxService } from '../services/math-jax.service';
import { MathJaxModule } from './math-jax.module';
@NgModule({
  declarations: [
    McqDetailComponent,
    ListMcqComponent,
    ExamComponent,
    ExamResultComponent 
  ],
  imports: [
    ModuleShared,
    RouterModule.forRoot([
      { path: 'mcq/mcqdetail/:id', component: McqDetailComponent },
      { path: 'mcq/listmcq', component: ListMcqComponent },
      { path: 'mcq/exam/:id', component: ExamComponent, canActivate: [AuthGuardService] },
      { path: 'mcq/exam/result/:id', component: ExamResultComponent, canActivate: [AuthGuardService] },
    ], { useHash: true }),
    MathJaxModule.forRoot({
      version: '2.7.5',
      config: 'TeX-AMS_HTML',
      hostname: 'cdnjs.cloudflare.com'
    })
  ],
  providers: [
    AuthGuardService,
    MathJaxService
  ],
})
export class MCQModule {

}
