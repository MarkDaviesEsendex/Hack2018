import { NgModule } from '@angular/core';
import { ReportIncidentComponent } from './report-incident/report-incident';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@NgModule({
	declarations: [ReportIncidentComponent],
	imports: [FormsModule, CommonModule],
	exports: [ReportIncidentComponent]
})
export class ComponentsModule {}
