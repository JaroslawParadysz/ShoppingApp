import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private fb: FormBuilder,
    private auth: AuthService) {
    this.loginForm = this.fb.group({
      username : ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
    console.log(this.loginForm);
  }

  ngOnInit(): void {
  }

  login() {
    this.auth.login(this.loginForm.value).subscribe(data => {
      this.auth.saveToken(data);
    },
    error => { console.log(error); });
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }
}
