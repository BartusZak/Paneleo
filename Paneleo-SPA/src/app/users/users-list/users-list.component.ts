import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { TitleService } from 'src/app/_services/title.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {
  users: User[];

  constructor(
    // private userService: UserService,
    // private alertify: AlertifyService,
    private route: ActivatedRoute,
    private titleService: TitleService
  ) {}

  ngOnInit() {
    this.titleService.setTitle('Lista Użytkowników');
    this.route.data.subscribe(data => {
      this.users = data['users'];
    });
  }

  // loadUsers() {
  //   this.userService.getUsers().subscribe(
  //     (users: User[]) => {
  //       this.users = users;
  //       console.log(users);
  //     },
  //     error => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }
}
