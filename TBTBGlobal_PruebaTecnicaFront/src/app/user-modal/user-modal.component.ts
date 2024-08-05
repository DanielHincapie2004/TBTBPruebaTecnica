import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user-modal',
  templateUrl: './user-modal.component.html',
  styleUrls: ['./user-modal.component.scss']
})
export class UserModalComponent {
  @Input() user: any;
  @Output() closeModal = new EventEmitter<void>();

  get isVisible(): boolean {
    return !!this.user;
  }

  close(): void {
    this.closeModal.emit();
  }
}
