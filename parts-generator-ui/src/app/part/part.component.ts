import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PartService } from './part.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Part } from './part.model';

@Component({
  selector: 'app-part',
  templateUrl: './part.component.html'
})
export class PartComponent implements OnInit {
  parts$: Observable<Array<string>>;
  partForm: FormGroup;

  constructor(private partService: PartService) { }

  public ngOnInit() {
    this.initForm();
    this.getParts();
  }

  private initForm() {
    this.partForm = new FormGroup({
      categoryCode: new FormControl(null, Validators.required),
      factoryCode: new FormControl(null, Validators.required),
      country: new FormControl(null, Validators.required)
    });
  }

  public addNew() {
    this.partService
      .addPart((this.partForm.value as Part))
      .subscribe((id) => {
        this.getParts();
        this.partForm.reset();
      });
  }

  private getParts() {
    this.parts$ = this.partService.getParts();
  }

}
