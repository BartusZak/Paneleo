import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subscription } from 'rxjs';
import { TitleService } from './_services/title.service';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { filter, map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  title: string;

  titleSubscription: Subscription;
  constructor(private authService: AuthService, private router: Router) {
    // this.router.events.subscribe(event => {
    //   if (event instanceof NavigationEnd) {
    //     const token = localStorage.getItem('token');
    //     this.logged = token ? true : false;
    //   }
    // });
  }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
