import { NgModule } from '@angular/core';
import { ModuleShared } from '../Modules/module.shared';

import { RouterModule } from '@angular/router';
import { AdminAuthGuardService } from '../Services/AdminAuthGuardService';
import { ChartsModule } from 'ng2-charts';
import { DashboardComponent } from '../Components/dasboard/dashboard.component';
import { NgxDaterangepickerMd } from 'ngx-daterangepicker-material';
@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    ModuleShared,
    ChartsModule,
    RouterModule.forRoot([
      { path: 'dashboard', component: DashboardComponent, canActivate: [AdminAuthGuardService] }
    ], { useHash: true }),
    NgxDaterangepickerMd.forRoot()
  ],
  providers: [
    AdminAuthGuardService
  ],
})
export class DashBoardModule {

}
