import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { trigger, style, transition, animate, state } from '@angular/animations';

@Component({
    selector: 'app-modal',
    templateUrl: './modal.component.html',
    styleUrls: ['./modal.component.scss'],
    animations: [
        trigger('starModal', [
            state('void', style({
                transform: 'translateY(100px)',
                opacity: 0
            })),
            transition(':enter', [
                animate('300ms cubic-bezier(0.35, 0, 0.25, 1)', style({
                    transform: 'translateY(0)',
                    opacity: 1
                }))
            ]),
            transition(':leave',
                animate('300ms cubic-bezier(0.35, 0, 0.25, 1)', style({
                    transform: 'translateY(-100px)',
                    opacity: 0
                })))
        ])
    ]
})
export class ModalComponent implements OnInit {
    @Input() public title: string;
    @Output() public close: EventEmitter<boolean> = new EventEmitter();

    ngOnInit() {
    }

    closeModal() {
        this.close.emit(false);
    }
}
