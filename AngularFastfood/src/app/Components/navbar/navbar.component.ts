import { Component, OnInit } from '@angular/core';
import { ClassLogin, Login } from 'src/app/Models/Login';
import { LoginService } from 'src/app/Services/login.service';
import { SocialAuthService, GoogleLoginProvider, SocialUser } from 'angularx-social-login';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ExternalAuthDto } from 'src/app/Models/DTO/ExternalAuthDto';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  //TODO: the screen size will adjust down to the smallest size it can accomodate but i can for the life of me 
  // just not get it show the content after dropdown the menu and collapse its just gone Example works so im missing something
  // But it works for now so im just going with it

  //Login element of this part should probably be a popup of some kind so that.

  _login = new ClassLogin();
  _isLoggedIn: boolean;
  externalLoggedIn: boolean;
  socialUser: SocialUser;
  loginForm: FormGroup;

  constructor(
    private loginService: LoginService,
    private formBuilder: FormBuilder,
    private socialAuthService: SocialAuthService
  ) { }

  ngOnInit(): void {
    this._isLoggedIn = false;
    //this.CheckLogin();

    //TODO: der skal skrive kommentare der forklare hvad der foregår, er lidt usikker på hvordan det fungere 100%
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
    //this.isLoggedIn = this.loginService.CheckIfLoggedOut();
    console.log("am i logged in " + this._isLoggedIn);
  }

  // en måde at gøre det på hvor funktionen bliver til en return type 
  // Dette bliver til et promise<SocialUser> som vi kan bruge i vores ExternalLogin
  SigninWithGoogle = () => {
    return this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }
  /* Dette fungere også men ikke sammen med det vi har gang med at logged ind i vores identity database
  SigninWithGoogle() {
    this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }
  */


  public ExternalLogin = () => {  
  console.log("dwdaw")
  this.SigninWithGoogle()
  .then(res => {
    const user: SocialUser = { ...res };
    this.socialUser = user;
    this._isLoggedIn = (user != null);
    const externalAuthDto: ExternalAuthDto = {
      provider: user.provider,
      idToken: user.idToken
    }
    this.ValidateExternalAuth(externalAuthDto);
  }, error => console.log(error))}

  private ValidateExternalAuth(externalAuth: ExternalAuthDto){
    this.loginService.externalLogin(externalAuth)
      .subscribe(res => {
        localStorage.setItem("token", res.token);
        this.externalLoggedIn == true;
      },
      error => {
        this.externalLoggedIn == false;
        console.log(error)
      });
  }

  LogoutExternal = () =>{
    localStorage.removeItem("token")

    if(this.externalLoggedIn){
      this.socialAuthService.signOut();
    }

    
  }

  //#region Identity Login

  //Makes a request to the server to log out it does this by deleting the cookie from identity
  LogOut() {
    this.loginService.ToLogOut()
      .subscribe()
  }


  //TODO needs a check whether or not token is still valid when opening website (request to server)
  CheckLogin() {
    this.loginService.CheckIfLoggedOut()
      .subscribe(res => {
        this._isLoggedIn = res;
        console.log("dwaw", this._isLoggedIn)
      })
  }

  ToLogin(_login: ClassLogin) {
    this.loginService.ToLogin(_login.email, _login.password)
      .subscribe(login => {
        this._login = login;
      })
  }
  //#endregion
}


