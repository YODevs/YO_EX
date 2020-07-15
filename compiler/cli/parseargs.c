//
// Created by AminCoder on 7/15/2020.
//

#include <stdio.h>
#include <stdbool.h>
#include "../err/clierr.h"
#include "parseargs.h"
#include "string.h"

#define BUILD "build"

void parse_args(int argc_i, char *argval[])
{
 char args[] = "";
 strcpy(args,argval[1]);

 if(strcmp(args,BUILD)== 0)
 {

 }else
 {
  //Command not found.
 cli_command_error(args);
 }

 return;
}
