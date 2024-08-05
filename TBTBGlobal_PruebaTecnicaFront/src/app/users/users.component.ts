import { Component, OnInit } from '@angular/core';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  users: any[] = [];
  filteredUsers: any[] = [];
  filterText: string = '';
  selectedUser: any = null;

  constructor(private usersService: UsersService) {}

  ngOnInit(): void {
    this.getUsers();
  }

   getUsers(): void {
    this.usersService.getUsers().subscribe({
      next: (res) => {
        this.users = res;
        this.users.forEach((user, index) => {
          user.image = `/assets/img${index + 1}.avif`
        });
        this.filteredUsers = this.users;
        console.log(this.filteredUsers);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  openModal(user: any): void {
    this.selectedUser = user;
  }

  closeModal(): void {
    this.selectedUser = null;
  }

  filterUsers(): void {
    const searchTerm = this.filterText.toLowerCase();
    this.filteredUsers = this.users.filter(user => 
      user.name.toLowerCase().includes(searchTerm) ||
      user.email.toLowerCase().includes(searchTerm) ||
      user.address.city.toLowerCase().includes(searchTerm)
    );
  }
}
