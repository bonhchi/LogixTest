import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  public form!: FormGroup;
  public submitted: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router) { }

  ngOnInit() {
    this._formControl()
  }

  private _formControl() {
    this.form = this.formBuilder.group({
      login: [{ value: '', disabled: false }, Validators.required],
    });
  }
  
  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  // Get API
  
  // Handle Events

  // Handle Submits
  public onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this._router.navigate(['home']);
    console.log(this.form.value)
  }

}
