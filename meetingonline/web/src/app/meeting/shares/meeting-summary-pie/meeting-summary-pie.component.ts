import { Component, Input, OnDestroy } from '@angular/core';
import { EChartOption } from 'echarts';
import * as echarts from 'echarts/lib/echarts';
import { MeetingSummary } from 'src/app/@core/models/meeting.model';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { takeWhile } from 'rxjs/operators';
import { isNullOrUndefined } from 'util';
import { MeetingSummaryType } from '../meeting.types';
import { TranslateService } from '@ngx-translate/core';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'vip-meeting-summary-pie',
  templateUrl: './meeting-summary-pie.component.html',
  styleUrls: ['./meeting-summary-pie.component.scss']
})
export class MeetingSummaryPieComponent implements OnDestroy {
  private destroy = false;

  @Input() type: MeetingSummaryType;
  @Input() value = 0;

  voteChartOption: EChartOption = {};
  summary: MeetingSummary;

  constructor(private appState: AppStateProvider, private localizer: TranslateService) {
    const self = this;

    console.log('pie contructor');
    this.appState.meetingSummary$.pipe(takeWhile(() => !this.destroy))
      .subscribe(summary => {
        console.log('pie', summary);
        
        if (summary) {
          self.summary = summary;
        } else {
          self.summary = { shares: 0, votes: 0, holders: 0, checkIn: 0, attendConfirmed: 0, checkInVotes: 0 };
        }

        if (isNullOrUndefined(self.type)) {
          return;
        }

        if (self.type === 'full') {
          self.setFullOptions();
        } else {
          self.setOptions();
        }
      });
  }

  ngOnDestroy(): void {
    this.destroy = true;
  }

  private async setFullOptions() {
    console.log('full option', this.value);
    const voteRatioPie: any = this.appState.theme.variables?.ratioPie;

    const text = await forkJoin(
      this.localizer.get('shares.meeting-summary.confirmVotes'),
      this.localizer.get('shares.meeting-summary.remainVotes'),
      this.localizer.get('shares.meeting-summary.holderVotes'),
    ).toPromise();

    this.voteChartOption = {
      tooltip: {
        trigger: 'item',
        formatter: '{b} : {c0} ({d}%)'
      },
      series: [
        {
          clockWise: true,
          type: 'pie',
          center: ['50%', '50%'],
          radius: [50, 100],
          data: [
            {
              value: this.value ?? 0,
              name: text[2],
              label: {
                show: true,
              },
              itemStyle: this.setItemStyle(3, voteRatioPie),
            },
            {
              value: this.summary.checkInVotes,
              name: text[0],
              label: {
                fontSize: 20,
                fontWeight: 'bold',
                position: 'center',
                formatter: '{d}%',
              },
              itemStyle: this.setItemStyle(1, voteRatioPie),
            },
            {
              value: this.summary.votes - this.summary.checkInVotes - this.value ?? 0,
              name: text[1],
              label: {
                show: false,
                position: 'inner'
              },
              itemStyle: this.setItemStyle(2, voteRatioPie),
            },

          ],
        }
      ]
    };
  }

  private setOptions() {
    if (isNullOrUndefined(this.summary?.votes) || isNullOrUndefined(this.appState.theme)) {
      return;
    }

    const voteRatioPie: any = this.appState.theme.variables?.ratioPie;
    const value = this.type === 'attendee' ? this.summary.checkInVotes : this.summary.confirmedVotes;
    const ratio = Math.round(value * 100 / this.summary.votes);

    this.voteChartOption = {
      series: [
        {
          name: ' ',
          clockWise: true,
          hoverAnimation: false,
          type: 'pie',
          center: ['50%', '50%'],
          radius: voteRatioPie.firstPieRadius,
          data: [
            {
              value: ratio,
              label: {
                normal: {
                  position: 'center',
                  formatter: '{d}%',
                }
              },
              tooltip: {
                show: false,
              },
              itemStyle: this.setItemStyle(1, voteRatioPie),
              hoverAnimation: false,
            },
            {
              value: 100 - ratio,
              name: ' ',
              tooltip: {
                show: false,
              },
              label: {
                normal: {
                  position: 'inner',
                },
              },
              itemStyle: {
                normal: {
                  color: this.appState.theme.variables.layoutBg,
                },
              },
            },
          ],
        },
        {
          clockWise: true,
          hoverAnimation: false,
          type: 'pie',
          center: ['50%', '50%'],
          radius: voteRatioPie.secondPieRadius,
          data: [
            {
              value: ratio,
              label: {
                normal: {
                  position: 'inner'
                },
              },
              tooltip: {
                show: false,
              },
              itemStyle: {
                normal: {
                  color: new echarts.graphic.LinearGradient(0, 0, 0, 1),
                },
              },
              hoverAnimation: false,
            },
            {
              value: 100 - ratio,
              tooltip: {
                show: false,
              },
              label: {
                normal: {
                  position: 'inner',
                },
              },
              itemStyle: this.setItemStyle(2, voteRatioPie)
            },
          ],
        },
      ],
    };
  }

  private setItemStyle(idx: number, style: any) {
    return {
      normal: {
        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
          {
            offset: 0,
            color: idx === 1 ? style.firstPieGradientLeft : idx === 2 ? style.secondPieGradientLeft : style.otherPieGradientLeft,
          },
          {
            offset: 1,
            color: idx === 1 ? style.firstPieGradientRight : idx === 2 ? style.secondPieGradientRight : style.otherPieGradientRight,
          },
        ]),
        shadowColor: idx === 1 ? style.firstPieShadowColor : idx === 2 ? style.secondPieShadowColor : style.otherShadowColor,
        shadowBlur: 0,
        shadowOffsetX: style.shadowOffsetX,
        shadowOffsetY: style.shadowOffsetY,
      },
    };
  }
}
