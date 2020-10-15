import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';

import { SocialAuthService, SocialUser } from "angularx-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { AuthenticationService } from 'src/app/Shared/Api/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user = { username: '', password: '', remember: false };
  error: string;
  isLoaded: boolean = false;

  Suser: SocialUser;
  loggedIn: boolean;


  constructor(private authService: SocialAuthService, private authenticationService: AuthenticationService, private router: Router) {
    // redirect to home if already logged in
    if (this.authenticationService.userValue) {
      this.router.navigate(['/']);
    }
  }

  signInWithGoogle(): void {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  signInWithFB(): void {
    this.authService.signIn(FacebookLoginProvider.PROVIDER_ID);
  }

  signOut(): void {
    this.authService.signOut();
  }

  ngOnInit(): void {
    this.authService.authState.subscribe((user) => {
      console.log(user);
      this.Suser = user;
      this.loggedIn = (user != null);
      this.authenticationService.loginByEmail(user.email)
        .pipe(first())
        .subscribe(
          data => {
            if (data == null)
              console.log("No user found");
            else {
              this.signOut();
              if (data.role == 'Admin')
                this.router.navigate(['/admin/showDishes']);
              else
                this.router.navigate(['/menu']);
            }

          },
          error => {
            this.signOut();
            this.error = error;
            console.log(error);
          });


    });

  }
  goToRegisterPage(): void {
    this.router.navigateByUrl('/createProfile');
    //this.dialogRef.close();
  }
  goToForgetPassword(): void {
    this.router.navigateByUrl('/forgetPassword');
  }
  onSubmit() {
    //console.log('User: ', this.user);
    //this.dialogRef.close();
    this.authenticationService.login(this.user.username, this.user.password)
      .pipe(first())
      .subscribe(
        data => {
          if (data.role == 'Admin')
            this.router.navigate(['/']);
          else
            this.router.navigate(['/Employee/CreateAttendance']);
        },
        error => {
          this.error = error;
          console.log(error);
        });
  }

}
