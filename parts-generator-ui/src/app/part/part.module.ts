import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PartRoutingModule } from './part-routing.module';
import { PartComponent } from './part.component';
import { PartService } from './part.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    PartRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [PartComponent],
  providers: [
    PartService
  ]
})
export class PartModule { }
