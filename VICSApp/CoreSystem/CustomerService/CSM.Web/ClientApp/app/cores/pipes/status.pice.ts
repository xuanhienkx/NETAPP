import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
    name: 'status'
})
export class StatusPipe implements PipeTransform {
    transform(val: boolean): string {
        return val?"Hoạt động":"Đóng";
    }
}