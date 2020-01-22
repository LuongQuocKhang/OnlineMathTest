import { NgModule } from '@angular/core';
import { ModuleShared } from '../Modules/module.shared';

import { RouterModule } from '@angular/router';
import { AuthGuardService } from '../Services/AuthGuardService';
import { StatisticComponent } from '../Components/statistic/statistic.component';
import { ChartsModule } from 'ng2-charts';

@NgModule({
  declarations: [
    StatisticComponent
  ],
  imports: [
    ModuleShared,
    ChartsModule,
    RouterModule.forRoot([
      { path: 'statistic/:id', component: StatisticComponent, canActivate: [AuthGuardService] }
    ], { useHash: true })
  ],
  providers: [
    AuthGuardService
  ],
})
export class StatisticModule {

}
