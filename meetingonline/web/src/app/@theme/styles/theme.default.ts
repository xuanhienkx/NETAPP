import { NbJSThemeOptions, DEFAULT_THEME as baseTheme } from '@nebular/theme';

const baseThemeVariables = baseTheme.variables;

export const DEFAULT_THEME = {
  name: 'default',
  base: 'default',
  variables: {
    ratioPie: {
      firstPieGradientLeft: baseThemeVariables.success,
      firstPieGradientRight: baseThemeVariables.success,
      firstPieShadowColor: 'rgba(0, 0, 0, 0)',
      firstPieRadius: ['60%', '90%'],

      secondPieGradientLeft: baseThemeVariables.warning,
      secondPieGradientRight: baseThemeVariables.warningLight,
      secondPieShadowColor: 'rgba(0, 0, 0, 0)',
      secondPieRadius: ['60%', '97%'],
      shadowOffsetX: '0',
      shadowOffsetY: '0',

      otherPieGradientLeft: baseThemeVariables.primary,
      otherPieGradientRight: baseThemeVariables.primary,
      otherPieShadowColor: 'rgba(0, 0, 0, 0)',
    }
  },
} as NbJSThemeOptions;
