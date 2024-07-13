��
tD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Seeding\ApplicationDbContextSeed.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
Seeding  '
;' (
public 
static 
class $
ApplicationDbContextSeed ,
{		 
public 

static 
void 
SeedEmailTemplate (
(( )
ModelBuilder) 5
modelBuilder6 B
)B C
{ 
modelBuilder 
. 
Entity 
< 
EmailTemplate )
>) *
(* +
)+ ,
., -
HasData- 4
(4 5
new 
{ 
Id 
= 
Guid 
. 
NewGuid !
(! "
)" #
,# $
TemplateName 
= 
$str -
,- .

SenderName 
= 
$str *
,* +
SenderEmail 
= 
$str :
,: ;
Category 
= 
$str $
,$ %
SubjectLine 
= 
$str 2
,2 3
PreHeaderText 
= 
$str  ;
,; <
PersonalizationTags #
=$ %
$str& ?
,? @
BodyContent 
= 
$str |
,| }
FooterContent 
= 
$str  Q
,Q R
CallToAction 
= 
$str O
,O P
Language 
= 
$str $
,$ %
RecipientType   
=   
$str    *
,  * +
CreateBy!! 
=!! 
$str!! #
,!!# $

CreateTime"" 
="" 
DateTime"" %
.""% &
Now""& )
,"") *
UpdateBy## 
=## 
$str## "
,##" #

UpdateTime$$ 
=$$ 
DateTime$$ %
.$$% &
Now$$& )
,$$) *
Status%% 
=%% 
$num%% 
}&& 
,&& 
new'' 
{(( 
Id)) 
=)) 
Guid)) 
.)) 
NewGuid)) !
())! "
)))" #
,))# $
TemplateName** 
=** 
$str** 4
,**4 5

SenderName++ 
=++ 
$str++ *
,++* +
SenderEmail,, 
=,, 
$str,, :
,,,: ;
Category-- 
=-- 
$str-- %
,--% &
SubjectLine.. 
=.. 
$str.. 3
,..3 4
PreHeaderText// 
=// 
$str//  F
,//F G
PersonalizationTags00 #
=00$ %
$str00& K
,00K L
BodyContent11 
=11 
$str	22 �
,
22� �
FooterContent33 
=33 
$str33  d
,33d e
CallToAction44 
=44 
$"55 
$str55 r
"55r s
,55s t
Language66 
=66 
$str66 $
,66$ %
RecipientType77 
=77 
$str77  *
,77* +
CreateBy88 
=88 
$str88 #
,88# $

CreateTime99 
=99 
DateTime99 %
.99% &
Now99& )
,99) *
UpdateBy:: 
=:: 
$str:: "
,::" #

UpdateTime;; 
=;; 
DateTime;; %
.;;% &
Now;;& )
,;;) *
Status<< 
=<< 
$num<< 
}== 
,== 
new>> 
{?? 
Id@@ 
=@@ 
Guid@@ 
.@@ 
NewGuid@@ !
(@@! "
)@@" #
,@@# $
TemplateNameAA 
=AA 
$strAA 0
,AA0 1

SenderNameBB 
=BB 
$strBB *
,BB* +
SenderEmailCC 
=CC 
$strCC :
,CC: ;
CategoryDD 
=DD 
$strDD #
,DD# $
SubjectLineEE 
=EE 
$strEE 3
,EE3 4
PreHeaderTextFF 
=FF 
$strFF  8
,FF8 9
PersonalizationTagsGG #
=GG$ %
$strGG& @
,GG@ A
BodyContentHH 
=HH 
$strHH t
,HHt u
FooterContentII 
=II 
$strII  Q
,IIQ R
CallToActionJJ 
=JJ 
$strJJ D
,JJD E
LanguageKK 
=KK 
$strKK $
,KK$ %
RecipientTypeLL 
=LL 
$strLL  *
,LL* +
CreateByMM 
=MM 
$strMM #
,MM# $

CreateTimeNN 
=NN 
DateTimeNN %
.NN% &
NowNN& )
,NN) *
UpdateByOO 
=OO 
$strOO "
,OO" #

UpdateTimePP 
=PP 
DateTimePP %
.PP% &
NowPP& )
,PP) *
StatusQQ 
=QQ 
$numQQ 
}RR 
,RR 
newSS 
{TT 
IdUU 
=UU 
GuidUU 
.UU 
NewGuidUU !
(UU! "
)UU" #
,UU# $
TemplateNameVV 
=VV 
$strVV ?
,VV? @

SenderNameWW 
=WW 
$strWW *
,WW* +
SenderEmailXX 
=XX 
$strXX :
,XX: ;
CategoryYY 
=YY 
$strYY %
,YY% &
SubjectLineZZ 
=ZZ 
$strZZ K
,ZZK L
PreHeaderText[[ 
=[[ 
$str[[  M
,[[M N
PersonalizationTags\\ #
=\\$ %
$str\\& ?
,\\? @
BodyContent]] 
=]] 
$str]] I
,]]I J
FooterContent^^ 
=^^ 
$str^^  f
,^^f g
CallToAction__ 
=__ 
$"`` 
$str	`` �
"
``� �
,
``� �
Languageaa 
=aa 
$straa $
,aa$ %
RecipientTypebb 
=bb 
$strbb  ,
,bb, -
CreateBycc 
=cc 
$strcc #
,cc# $

CreateTimedd 
=dd 
DateTimedd %
.dd% &
Nowdd& )
,dd) *
UpdateByee 
=ee 
$stree "
,ee" #

UpdateTimeff 
=ff 
DateTimeff %
.ff% &
Nowff& )
,ff) *
Statusgg 
=gg 
$numgg 
}hh 
,hh 
newii 
{jj 
Idkk 
=kk 
Guidkk 
.kk 
NewGuidkk !
(kk! "
)kk" #
,kk# $
TemplateNamell 
=ll 
$strll /
,ll/ 0

SenderNamemm 
=mm 
$strmm *
,mm* +
SenderEmailnn 
=nn 
$strnn :
,nn: ;
Categoryoo 
=oo 
$stroo %
,oo% &
SubjectLinepp 
=pp 
$strpp 3
,pp3 4
PreHeaderTextqq 
=qq 
$strqq  G
,qqG H
PersonalizationTagsrr #
=rr$ %
$strrr& @
,rr@ A
BodyContentss 
=ss 
$strtt t
,ttt u
FooterContentuu 
=uu 
$struu  Q
,uuQ R
CallToActionvv 
=vv 
$strvv M
,vvM N
Languageww 
=ww 
$strww $
,ww$ %
RecipientTypexx 
=xx 
$strxx  *
,xx* +
CreateByyy 
=yy 
$stryy #
,yy# $

CreateTimezz 
=zz 
DateTimezz %
.zz% &
Nowzz& )
,zz) *
UpdateBy{{ 
={{ 
$str{{ "
,{{" #

UpdateTime|| 
=|| 
DateTime|| %
.||% &
Now||& )
,||) *
Status}} 
=}} 
$num}} 
}~~ 
,~~ 
new 
{
�� 
Id
�� 
=
�� 
Guid
�� 
.
�� 
NewGuid
�� !
(
��! "
)
��" #
,
��# $
TemplateName
�� 
=
�� 
$str
�� 4
,
��4 5

SenderName
�� 
=
�� 
$str
�� )
,
��) *
SenderEmail
�� 
=
�� 
$str
�� 4
,
��4 5
Category
�� 
=
�� 
$str
�� )
,
��) *
SubjectLine
�� 
=
�� 
$str
�� /
,
��/ 0
PreHeaderText
�� 
=
�� 
$str
��  0
,
��0 1!
PersonalizationTags
�� #
=
��$ %
$str
��& 2
,
��2 3
BodyContent
�� 
=
�� 
$str
�� e
,
��e f
FooterContent
�� 
=
�� 
$str
��  Q
,
��Q R
CallToAction
�� 
=
�� 
$str
�� H
,
��H I
Language
�� 
=
�� 
$str
�� $
,
��$ %
RecipientType
�� 
=
�� 
$str
��  *
,
��* +
CreateBy
�� 
=
�� 
$str
�� #
,
��# $

CreateTime
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
,
��) *
UpdateBy
�� 
=
�� 
$str
�� "
,
��" #

UpdateTime
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
,
��) *
Status
�� 
=
�� 
$num
�� 
}
�� 
,
�� 
new
�� 
{
�� 
Id
�� 
=
�� 
Guid
�� 
.
�� 
NewGuid
�� !
(
��! "
)
��" #
,
��# $
TemplateName
�� 
=
�� 
$str
�� C
,
��C D

SenderName
�� 
=
�� 
$str
�� *
,
��* +
SenderEmail
�� 
=
�� 
$str
�� :
,
��: ;
Category
�� 
=
�� 
$str
�� -
,
��- .
SubjectLine
�� 
=
�� 
$str
�� <
,
��< =
PreHeaderText
�� 
=
�� 
$str
��  >
,
��> ?!
PersonalizationTags
�� #
=
��$ %
$str
��& ?
,
��? @
BodyContent
�� 
=
�� 
$str
�� g
,
��g h
FooterContent
�� 
=
�� 
$str
��  Q
,
��Q R
CallToAction
�� 
=
�� 
$str
�� O
,
��O P
Language
�� 
=
�� 
$str
�� $
,
��$ %
RecipientType
�� 
=
�� 
$str
��  '
,
��' (
CreateBy
�� 
=
�� 
$str
�� #
,
��# $

CreateTime
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
,
��) *
UpdateBy
�� 
=
�� 
$str
�� "
,
��" #

UpdateTime
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
,
��) *
Status
�� 
=
�� 
$num
�� 
}
�� 
,
�� 
new
�� 
{
�� 
Id
�� 
=
�� 
Guid
�� 
.
�� 
NewGuid
�� !
(
��! "
)
��" #
,
��# $
TemplateName
�� 
=
�� 
$str
�� 8
,
��8 9

SenderName
�� 
=
�� 
$str
�� *
,
��* +
SenderEmail
�� 
=
�� 
$str
�� :
,
��: ;
Category
�� 
=
�� 
$str
�� 2
,
��2 3
SubjectLine
�� 
=
�� 
$str
�� >
,
��> ?
PreHeaderText
�� 
=
�� 
$str
��  B
,
��B C!
PersonalizationTags
�� #
=
��$ %
$str
��& ?
,
��? @
BodyContent
�� 
=
�� 
$str
�� e
,
��e f
FooterContent
�� 
=
�� 
$str
��  Q
,
��Q R
CallToAction
�� 
=
�� 
$str
�� O
,
��O P
Language
�� 
=
�� 
$str
�� $
,
��$ %
RecipientType
�� 
=
�� 
$str
��  ,
,
��, -
CreateBy
�� 
=
�� 
$str
�� #
,
��# $

CreateTime
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
,
��) *
UpdateBy
�� 
=
�� 
$str
�� "
,
��" #

UpdateTime
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
,
��) *
Status
�� 
=
�� 
$num
�� 
}
�� 
,
�� 
new
�� 
{
�� 
Id
�� 
=
�� 
Guid
�� 
.
�� 
NewGuid
�� !
(
��! "
)
��" #
,
��# $
TemplateName
�� 
=
�� 
$str
�� 7
,
��7 8

SenderName
�� 
=
�� 
$str
�� *
,
��* +
SenderEmail
�� 
=
�� 
$str
�� :
,
��: ;
Category
�� 
=
�� 
$str
�� 2
,
��2 3
SubjectLine
�� 
=
�� 
$str
�� >
,
��> ?
PreHeaderText
�� 
=
�� 
$str
��  F
,
��F G!
PersonalizationTags
�� #
=
��$ %
$str
��& ?
,
��? @
BodyContent
�� 
=
�� 
$str
�� e
,
��e f
FooterContent
�� 
=
�� 
$str
��  Q
,
��Q R
CallToAction
�� 
=
�� 
$str
�� O
,
��O P
Language
�� 
=
�� 
$str
�� $
,
��$ %
RecipientType
�� 
=
�� 
$str
��  ,
,
��, -
CreateBy
�� 
=
�� 
$str
�� #
,
��# $

CreateTime
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
,
��) *
UpdateBy
�� 
=
�� 
$str
�� "
,
��" #

UpdateTime
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
,
��) *
Status
�� 
=
�� 
$num
�� 
}
�� 
)
�� 	
;
��	 

}
�� 
public
�� 

static
�� 
void
�� 
SeedAdminAccount
�� '
(
��' (
ModelBuilder
��( 4
modelBuilder
��5 A
)
��A B
{
�� 
var
�� 
studentRoleId
�� 
=
�� 
$str
�� B
;
��B C
var
�� 
instructorRoleId
�� 
=
�� 
$str
�� E
;
��E F
var
�� 
adminRoleId
�� 
=
�� 
$str
�� @
;
��@ A
var
�� 
roles
�� 
=
�� 
new
�� 
List
�� 
<
�� 
IdentityRole
�� )
>
��) *
{
�� 	
new
�� 
IdentityRole
�� 
{
�� 
Id
�� 
=
�� 
studentRoleId
�� "
,
��" #
ConcurrencyStamp
��  
=
��! "
StaticUserRoles
��# 2
.
��2 3
Student
��3 :
,
��: ;
Name
�� 
=
�� 
StaticUserRoles
�� &
.
��& '
Student
��' .
,
��. /
NormalizedName
�� 
=
��  
StaticUserRoles
��! 0
.
��0 1
Student
��1 8
,
��8 9
}
�� 
,
�� 
new
�� 
IdentityRole
�� 
{
�� 
Id
�� 
=
�� 
instructorRoleId
�� %
,
��% &
ConcurrencyStamp
��  
=
��! "
StaticUserRoles
��# 2
.
��2 3

Instructor
��3 =
,
��= >
Name
�� 
=
�� 
StaticUserRoles
�� &
.
��& '

Instructor
��' 1
,
��1 2
NormalizedName
�� 
=
��  
StaticUserRoles
��! 0
.
��0 1

Instructor
��1 ;
,
��; <
}
�� 
,
�� 
new
�� 
IdentityRole
�� 
{
�� 
Id
�� 
=
�� 
adminRoleId
��  
,
��  !
ConcurrencyStamp
��  
=
��! "
StaticUserRoles
��# 2
.
��2 3
Admin
��3 8
,
��8 9
Name
�� 
=
�� 
StaticUserRoles
�� &
.
��& '
Admin
��' ,
,
��, -
NormalizedName
�� 
=
��  
StaticUserRoles
��! 0
.
��0 1
Admin
��1 6
,
��6 7
}
�� 
}
�� 	
;
��	 

modelBuilder
�� 
.
�� 
Entity
�� 
<
�� 
IdentityRole
�� (
>
��( )
(
��) *
)
��* +
.
��+ ,
HasData
��, 3
(
��3 4
roles
��4 9
)
��9 :
;
��: ;
var
�� 
adminUserId
�� 
=
�� 
$str
�� +
;
��+ ,
var
�� 
hasher
�� 
=
�� 
new
�� 
PasswordHasher
�� '
<
��' (
ApplicationUser
��( 7
>
��7 8
(
��8 9
)
��9 :
;
��: ;
var
�� 
	adminUser
�� 
=
�� 
new
�� 
ApplicationUser
�� +
{
�� 	
Id
�� 
=
�� 
adminUserId
�� 
,
�� 
Gender
�� 
=
�� 
$str
�� 
,
�� 
FullName
�� 
=
�� 
$str
�� #
,
��# $
	BirthDate
�� 
=
�� 
new
�� 
DateTime
�� $
(
��$ %
$num
��% )
,
��) *
$num
��+ ,
,
��, -
$num
��. /
)
��/ 0
,
��0 1
	AvatarUrl
�� 
=
�� 
$str
�� 8
,
��8 9
Country
�� 
=
�� 
$str
�� 
,
��  
Address
�� 
=
�� 
$str
�� $
,
��$ %
	TaxNumber
�� 
=
�� 
$str
�� #
,
��# $
UserName
�� 
=
�� 
$str
�� (
,
��( ) 
NormalizedUserName
�� 
=
��  
$str
��! 2
,
��2 3
Email
�� 
=
�� 
$str
�� %
,
��% &
NormalizedEmail
�� 
=
�� 
$str
�� /
,
��/ 0
EmailConfirmed
�� 
=
�� 
true
�� !
,
��! "
PasswordHash
�� 
=
�� 
hasher
�� !
.
��! "
HashPassword
��" .
(
��. /
null
��/ 3
,
��3 4
$str
��5 @
)
��@ A
,
��A B
SecurityStamp
�� 
=
�� 
Guid
��  
.
��  !
NewGuid
��! (
(
��( )
)
��) *
.
��* +
ToString
��+ 3
(
��3 4
)
��4 5
,
��5 6
ConcurrencyStamp
�� 
=
�� 
Guid
�� #
.
��# $
NewGuid
��$ +
(
��+ ,
)
��, -
.
��- .
ToString
��. 6
(
��6 7
)
��7 8
,
��8 9
PhoneNumber
�� 
=
�� 
$str
�� &
,
��& '"
PhoneNumberConfirmed
��  
=
��! "
true
��# '
,
��' (
TwoFactorEnabled
�� 
=
�� 
false
�� $
,
��$ %

LockoutEnd
�� 
=
�� 
null
�� 
,
�� 
LockoutEnabled
�� 
=
�� 
true
�� !
,
��! "
AccessFailedCount
�� 
=
�� 
$num
��  !
,
��! "

UpdateTime
�� 
=
�� 
new
�� 
DateTime
�� %
(
��% &
$num
��& *
,
��* +
$num
��, -
,
��- .
$num
��/ 1
)
��1 2
}
�� 	
;
��	 

modelBuilder
�� 
.
�� 
Entity
�� 
<
�� 
ApplicationUser
�� +
>
��+ ,
(
��, -
)
��- .
.
��. /
HasData
��/ 6
(
��6 7
	adminUser
��7 @
)
��@ A
;
��A B
modelBuilder
�� 
.
�� 
Entity
�� 
<
�� 
IdentityUserRole
�� ,
<
��, -
string
��- 3
>
��3 4
>
��4 5
(
��5 6
)
��6 7
.
��7 8
HasData
��8 ?
(
��? @
new
��@ C
IdentityUserRole
��D T
<
��T U
string
��U [
>
��[ \
{
�� 	
RoleId
�� 
=
�� 
adminRoleId
��  
,
��  !
UserId
�� 
=
�� 
adminUserId
��  
}
�� 	
)
��	 

;
��
 
}
�� 
}�� �'
tD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\UserManagerRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
{ 
public 

class !
UserManagerRepository &
:' ("
IUserManagerRepository) ?
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
public !
UserManagerRepository $
($ %
UserManager% 0
<0 1
ApplicationUser1 @
>@ A
userManagerB M
)M N
{ 	
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
ApplicationUser )
>) *
FindByEmailAsync+ ;
(; <
string< B
emailC H
)H I
{ 	
return 
await 
_userManager %
.% &
FindByEmailAsync& 6
(6 7
email7 <
)< =
;= >
} 	
public 
async 
Task 
< 
bool 
> )
CheckIfPhoneNumberExistsAsync  =
(= >
string> D
phoneNumberE P
)P Q
{ 	
return 
await 
_userManager %
.% &
Users& +
.+ ,
AnyAsync, 4
(4 5
u5 6
=>7 9
u: ;
.; <
PhoneNumber< G
==H J
phoneNumberK V
)V W
;W X
} 	
public   
async   
Task   
<   
IdentityResult   (
>  ( )
CreateAsync  * 5
(  5 6
ApplicationUser  6 E
user  F J
,  J K
string  L R
password  S [
)  [ \
{!! 	
return"" 
await"" 
_userManager"" %
.""% &
CreateAsync""& 1
(""1 2
user""2 6
,""6 7
password""8 @
)""@ A
;""A B
}## 	
public%% 
async%% 
Task%% 
<%% 
IdentityResult%% (
>%%( )
AddToRoleAsync%%* 8
(%%8 9
ApplicationUser%%9 H
user%%I M
,%%M N
string%%O U
role%%V Z
)%%Z [
{&& 	
return'' 
await'' 
_userManager'' %
.''% &
AddToRoleAsync''& 4
(''4 5
user''5 9
,''9 :
role''; ?
)''? @
;''@ A
}(( 	
public** 
async** 
Task** 
<** 
ApplicationUser** )
>**) *
FindByIdAsync**+ 8
(**8 9
string**9 ?
userId**@ F
)**F G
{++ 	
return,, 
await,, 
_userManager,, %
.,,% &
FindByIdAsync,,& 3
(,,3 4
userId,,4 :
),,: ;
;,,; <
}-- 	
public.. 
async.. 
Task.. 
<.. 
ApplicationUser.. )
>..) *
FindByPhoneAsync..+ ;
(..; <
string..< B
phoneNumber..C N
)..N O
{// 	
return00 
await00 
_userManager00 %
.00% &
Users00& +
.00+ ,
FirstOrDefaultAsync00, ?
(00? @
u00@ A
=>00B D
u00E F
.00F G
PhoneNumber00G R
==00S U
phoneNumber00V a
)00a b
;00b c
}11 	
public33 
Task33 
<33 
List33 
<33 
ApplicationUser33 (
>33( )
>33) *
GetInstructorUser33+ <
(33< =
)33= >
{44 	
throw55 
new55 #
NotImplementedException55 -
(55- .
)55. /
;55/ 0
}66 	
public88 
Task88 
<88 
List88 
<88 
ApplicationUser88 (
>88( )
>88) *
GetStudentUser88+ 9
(889 :
)88: ;
{99 	
throw:: 
new:: #
NotImplementedException:: -
(::- .
)::. /
;::/ 0
};; 	
public== 
async== 
Task== 
<== 
IEnumerable== %
<==% &
ApplicationUser==& 5
>==5 6
>==6 7
GetUsersInRoleAsync==8 K
(==K L
string==L R
role==S W
)==W X
{>> 	
return?? 
await?? 
_userManager?? %
.??% &
GetUsersInRoleAsync??& 9
(??9 :
role??: >
)??> ?
;??? @
}@@ 	
}AA 
}BB �4
iD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\UnitOfWork.cs
	namespace		 	
Cursus		
 
.		 
LMS		 
.		 

DataAccess		 
.		  

Repository		  *
{

 
public 

class 

UnitOfWork 
: 
IUnitOfWork )
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
public 
IStudentRepository !
StudentRepository" 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
public !
IInstructorRepository $ 
InstructorRepository% 9
{: ;
get< ?
;? @
setA D
;D E
}F G
public 
ICategoryRepository "
CategoryRepository# 5
{6 7
get8 ;
;; <
}= >
public $
IEmailTemplateRepository '#
EmailTemplateRepository( ?
{@ A
getB E
;E F
}G H
public "
IUserManagerRepository %!
UserManagerRepository& ;
{< =
get> A
;A B
}C D
public (
IInstructorCommentRepository +'
InstructorCommentRepository, G
{H I
getJ M
;M N
}O P
public "
IPaymentCardRepository %!
PaymentCardRepository& ;
{< =
get> A
;A B
setC F
;F G
}H I
public 
ICourseRepository  
CourseRepository! 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public '
IInstructorRatingRepository *&
InstructorRatingRepository+ E
{F G
getH K
;K L
setM P
;P Q
}R S
public $
ICourseVersionRepository '#
CourseVersionRepository( ?
{@ A
getB E
;E F
}G H
public +
ICourseSectionVersionRepository .*
CourseSectionVersionRepository/ M
{N O
getP S
;S T
}U V
public ,
 ISectionDetailsVersionRepository /+
SectionDetailsVersionRepository0 O
{P Q
getR U
;U V
}W X
public *
ICourseVersionStatusRepository -)
CourseVersionStatusRepository. K
{L M
getN Q
;Q R
}S T
public +
ICourseVersionCommentRepository .*
CourseVersionCommentRepository/ M
{N O
getP S
;S T
}U V
public $
IStudentCourseRepository '#
StudentCourseRepository( ?
{@ A
getB E
;E F
}G H
public 
ILevelRepository 
LevelRepository  /
{0 1
get2 5
;5 6
}7 8
public 

UnitOfWork 
(  
ApplicationDbContext .
context/ 6
,6 7
UserManager8 C
<C D
ApplicationUserD S
>S T
userManagerU `
)` a
{   	
_context!! 
=!! 
context!! 
;!! 
StudentRepository"" 
="" 
new""  #
StudentRepository""$ 5
(""5 6
_context""6 >
)""> ?
;""? @ 
InstructorRepository##  
=##! "
new### & 
InstructorRepository##' ;
(##; <
_context##< D
)##D E
;##E F!
PaymentCardRepository$$ !
=$$" #
new$$$ '!
PaymentCardRepository$$( =
($$= >
_context$$> F
)$$F G
;$$G H
CategoryRepository%% 
=%%  
new%%! $
CategoryRepository%%% 7
(%%7 8
_context%%8 @
)%%@ A
;%%A B#
EmailTemplateRepository&& #
=&&$ %
new&&& )#
EmailTemplateRepository&&* A
(&&A B
_context&&B J
)&&J K
;&&K L!
UserManagerRepository'' !
=''" #
new''$ '!
UserManagerRepository''( =
(''= >
userManager''> I
)''I J
;''J K'
InstructorCommentRepository(( '
=((( )
new((* -'
InstructorCommentRepository((. I
(((I J
_context((J R
)((R S
;((S T&
InstructorRatingRepository)) &
=))' (
new))) ,&
InstructorRatingRepository))- G
())G H
_context))H P
)))P Q
;))Q R
CourseRepository** 
=** 
new** "
CourseRepository**# 3
(**3 4
_context**4 <
)**< =
;**= >#
CourseVersionRepository++ #
=++$ %
new++& )#
CourseVersionRepository++* A
(++A B
_context++B J
)++J K
;++K L*
CourseSectionVersionRepository,, *
=,,+ ,
new,,- 0*
CourseSectionVersionRepository,,1 O
(,,O P
_context,,P X
),,X Y
;,,Y Z+
SectionDetailsVersionRepository-- +
=--, -
new--. 1+
SectionDetailsVersionRepository--2 Q
(--Q R
_context--R Z
)--Z [
;--[ \)
CourseVersionStatusRepository.. )
=..* +
new.., /)
CourseVersionStatusRepository..0 M
(..M N
_context..N V
)..V W
;..W X*
CourseVersionCommentRepository// *
=//+ ,
new//- 0*
CourseVersionCommentRepository//1 O
(//O P
_context//P X
)//X Y
;//Y Z#
StudentCourseRepository00 #
=00$ %
new00& )#
StudentCourseRepository00* A
(00A B
_context00B J
)00J K
;00K L
LevelRepository11 
=11 
new11 !
LevelRepository11" 1
(111 2
_context112 :
)11: ;
;11; <
}22 	
public44 
async44 
Task44 
<44 
int44 
>44 
	SaveAsync44 (
(44( )
)44) *
{55 	
return66 
await66 
_context66 !
.66! "
SaveChangesAsync66" 2
(662 3
)663 4
;664 5
}77 	
}88 
}99 �
pD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\StudentRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class 
StudentRepository 
:  

Repository! +
<+ ,
Student, 3
>3 4
,4 5
IStudentRepository6 H
{ 
private		 
readonly		  
ApplicationDbContext		 )
_context		* 2
;		2 3
public 

StudentRepository 
(  
ApplicationDbContext 1
context2 9
)9 :
:; <
base= A
(A B
contextB I
)I J
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 
Student 
student &
)& '
{ 
_context 
. 
Students 
. 
Update  
(  !
student! (
)( )
;) *
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (
Student( /
>/ 0
students1 9
)9 :
{ 
_context 
. 
Students 
. 
UpdateRange %
(% &
students& .
). /
;/ 0
} 
public 

async 
Task 
< 
Student 
> 
AddAsync '
(' (
Student( /
student0 7
)7 8
{ 
var 
entityEntry 
= 
await 
_context  (
.( )
Students) 1
.1 2
AddAsync2 :
(: ;
student; B
)B C
;C D
return 
entityEntry 
. 
Entity !
;! "
} 
} �
vD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\StudentCourseRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class #
StudentCourseRepository $
:% &

Repository' 1
<1 2
StudentCourse2 ?
>? @
,@ A$
IStudentCourseRepositoryB Z
{ 
private		 
readonly		  
ApplicationDbContext		 )
_context		* 2
;		2 3
public 
#
StudentCourseRepository "
(" # 
ApplicationDbContext# 7
context8 ?
)? @
:A B
baseC G
(G H
contextH O
)O P
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 
StudentCourse $
studentCourse% 2
)2 3
{ 
_context 
. 
StudentCourses 
.  
Update  &
(& '
studentCourse' 4
)4 5
;5 6
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (
StudentCourse( 5
>5 6
studentCourses7 E
)E F
{ 
_context 
. 
StudentCourses 
.  
UpdateRange  +
(+ ,
studentCourses, :
): ;
;; <
} 
} �
~D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\SectionDetailsVersionRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class +
SectionDetailsVersionRepository ,
:- .

Repository/ 9
<9 :!
SectionDetailsVersion: O
>O P
,P Q,
 ISectionDetailsVersionRepositoryR r
{		 
private

 
readonly

  
ApplicationDbContext

 )
_context

* 2
;

2 3
public 
+
SectionDetailsVersionRepository *
(* + 
ApplicationDbContext+ ?
context@ G
)G H
:I J
baseK O
(O P
contextP W
)W X
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( !
SectionDetailsVersion ,!
sectionDetailsVersion- B
)B C
{ 
_context 
. "
SectionDetailsVersions '
.' (
Update( .
(. /!
sectionDetailsVersion/ D
)D E
;E F
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (!
SectionDetailsVersion( =
>= >"
sectionDetailsVersions? U
)U V
{ 
_context 
. "
SectionDetailsVersions '
.' (
UpdateRange( 3
(3 4"
sectionDetailsVersions4 J
)J K
;K L
} 
public 

async 
Task 
< 
List 
< !
SectionDetailsVersion 0
>0 1
?1 2
>2 3@
4GetSectionDetailsVersionsOfCourseSectionVersionAsync4 h
( 
Guid "
courseSectionVersionId #
,# $
bool 
? 
asNoTracking 
) 
{   
return!! 
asNoTracking!! 
is!! 
true!! #
?"" 
await"" 
_context"" 
."" "
SectionDetailsVersions"" 3
.## 
AsNoTracking## 
(## 
)## 
.$$ 
Where$$ 
($$ 
x$$ 
=>$$ 
x$$ 
.$$ "
CourseSectionVersionId$$ 4
==$$5 7"
courseSectionVersionId$$8 N
)$$N O
.%% 
ToListAsync%% 
(%% 
)%% 
:&& 
await&& 
_context&& 
.&& "
SectionDetailsVersions&& 3
.'' 
Where'' 
('' 
x'' 
=>'' 
x'' 
.'' "
CourseSectionVersionId'' 4
==''5 7"
courseSectionVersionId''8 N
)''N O
.(( 
ToListAsync(( 
((( 
)(( 
;(( 
})) 
public++ 

async++ 
Task++ 
<++ !
SectionDetailsVersion++ +
?+++ ,
>++, -(
GetSectionDetailsVersionById++. J
(++J K
Guid++K O
	detailsId++P Y
)++Y Z
{,, 
return-- 
await-- 
_context-- 
.-- "
SectionDetailsVersions-- 4
.--4 5
FirstOrDefaultAsync--5 H
(--H I
x--I J
=>--K M
x--N O
.--O P
Id--P R
==--S U
	detailsId--V _
)--_ `
;--` a
}.. 
}// �0
iD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\Repository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public		 
class		 

Repository		 
<		 
T		 
>		 
:		 
IRepository		 (
<		( )
T		) *
>		* +
where		, 1
T		2 3
:		4 5
class		6 ;
{

 
private 
readonly  
ApplicationDbContext )
_context* 2
;2 3
internal 
DbSet 
< 
T 
> 
dbSet 
; 
public 


Repository 
(  
ApplicationDbContext *
context+ 2
)2 3
{ 
_context 
= 
context 
; 
dbSet 
= 
_context 
. 
Set 
< 
T 
> 
(  
)  !
;! "
} 
public 

async 
Task 
AddAsync 
( 
T  
entity! '
)' (
{ 
await 
dbSet 
. 
AddAsync 
( 
entity #
)# $
;$ %
} 
public 

async 
Task 
AddRangeAsync #
(# $
IEnumerable$ /
</ 0
T0 1
>1 2
entities3 ;
); <
{ 
await 
dbSet 
. 
AddRangeAsync !
(! "
entities" *
)* +
;+ ,
} 
public$$ 

async$$ 
Task$$ 
<$$ 
T$$ 
?$$ 
>$$ 
GetAsync$$ "
($$" #

Expression$$# -
<$$- .
Func$$. 2
<$$2 3
T$$3 4
,$$4 5
bool$$6 :
>$$: ;
>$$; <
filter$$= C
,$$C D
string$$E K
?$$K L
includeProperties$$M ^
=$$_ `
null$$a e
)$$e f
{%% 

IQueryable&& 
<&& 
T&& 
>&& 
query&& 
=&& 
dbSet&& #
;&&# $
query'' 
='' 
query'' 
.'' 
Where'' 
('' 
filter'' "
)''" #
;''# $
if)) 

()) 
!)) 
string)) 
.)) 
IsNullOrEmpty)) !
())! "
includeProperties))" 3
)))3 4
)))4 5
{** 	
foreach++ 
(++ 
var++ 
property++ !
in++" $
includeProperties++% 6
.++6 7
Split++7 <
(++< =
new++= @
char++A E
[++E F
]++F G
{++H I
$char++J M
}++N O
,++O P
StringSplitOptions++Q c
.++c d
RemoveEmptyEntries++d v
)++v w
)++w x
{,, 
query-- 
=-- 
query-- 
.-- 
Include-- %
(--% &
property--& .
)--. /
;--/ 0
}.. 
}// 	
return11 
await11 
query11 
.11 
FirstOrDefaultAsync11 .
(11. /
)11/ 0
;110 1
}22 
public== 

async== 
Task== 
<== 
IEnumerable== !
<==! "
T==" #
>==# $
>==$ %
GetAllAsync==& 1
(==1 2

Expression==2 <
<==< =
Func=== A
<==A B
T==B C
,==C D
bool==E I
>==I J
>==J K
?==K L
filter==M S
===T U
null==V Z
,==Z [
string>> 
?>> 
includeProperties>> !
=>>" #
null>>$ (
)>>( )
{?? 

IQueryable@@ 
<@@ 
T@@ 
>@@ 
query@@ 
=@@ 
dbSet@@ #
;@@# $
ifBB 

(BB 
filterBB 
!=BB 
nullBB 
)BB 
{CC 	
queryDD 
=DD 
queryDD 
.DD 
WhereDD 
(DD  
filterDD  &
)DD& '
;DD' (
}EE 	
ifGG 

(GG 
!GG 
stringGG 
.GG 
IsNullOrEmptyGG !
(GG! "
includePropertiesGG" 3
)GG3 4
)GG4 5
{HH 	
foreachII 
(II 
varII 
propertyII !
inII" $
includePropertiesII% 6
.II6 7
SplitII7 <
(II< =
newII= @
charIIA E
[IIE F
]IIF G
{IIH I
$charIIJ M
}IIN O
,IIO P
StringSplitOptionsIIQ c
.IIc d
RemoveEmptyEntriesIId v
)IIv w
)IIw x
{JJ 
queryKK 
=KK 
queryKK 
.KK 
IncludeKK %
(KK% &
propertyKK& .
)KK. /
;KK/ 0
}LL 
}MM 	
returnOO 
awaitOO 
queryOO 
.OO 
ToListAsyncOO &
(OO& '
)OO' (
;OO( )
}PP 
publicRR 

voidRR 
RemoveRR 
(RR 
TRR 
entityRR 
)RR  
{SS 
dbSetTT 
.TT 
RemoveTT 
(TT 
entityTT 
)TT 
;TT 
}UU 
publicWW 

voidWW 
RemoveRangeWW 
(WW 
IEnumerableWW '
<WW' (
TWW( )
>WW) *
entitiesWW+ 3
)WW3 4
{XX 
dbSetYY 
.YY 
RemoveRangeYY 
(YY 
entitiesYY "
)YY" #
;YY# $
}ZZ 
}[[ �
tD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\PaymentCardRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
{ 
public		 

class		 !
PaymentCardRepository		 &
:		' (

Repository		) 3
<		3 4
PaymentCard		4 ?
>		? @
,		@ A"
IPaymentCardRepository		B X
{

 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
public !
PaymentCardRepository $
($ % 
ApplicationDbContext% 9
context: A
)A B
:C D
baseE I
(I J
contextJ Q
)Q R
{ 	
_context 
= 
context 
; 
} 	
public 
void 
Update 
( 
PaymentCard &
paymentCard' 2
)2 3
{ 	
_context 
. 
PaymentCards !
.! "
Update" (
(( )
paymentCard) 4
)4 5
;5 6
} 	
public 
void 
UpdateRange 
(  
IEnumerable  +
<+ ,
PaymentCard, 7
>7 8
paymentCards9 E
)E F
{ 	
_context 
. 
PaymentCards !
.! "
UpdateRange" -
(- .
paymentCards. :
): ;
;; <
} 	
public 
async 
Task 
< 
PaymentCard %
?% &
>& '!
CardNumberExistsAsync( =
(= >
string> D

cardNumberE O
)O P
{ 	
return 
await 
_context "
." #
PaymentCards# /
./ 0
FirstOrDefaultAsync0 C
(C D
xD E
=>F H
xI J
.J K

CardNumberK U
==V X

cardNumberY c
)c d
;d e
} 	
public!! 
async!! 
Task!! 
<!! 
PaymentCard!! %
?!!% &
>!!& '
GetCardByUserId!!( 7
(!!7 8
string!!8 >
id!!? A
)!!A B
{"" 	
return## 
await## 
_context## !
.##! "
PaymentCards##" .
.##. /
FirstOrDefaultAsync##/ B
(##B C
x##C D
=>##E G
x##H I
.##I J
UserId##J P
==##Q S
id##T V
)##V W
;##W X
}$$ 	
public&& 
async&& 
Task&& 
<&& 
PaymentCard&& %
>&&% &
AddAsync&&' /
(&&/ 0
PaymentCard&&0 ;
paymentCard&&< G
)&&G H
{'' 	
var(( 
entityEntry(( 
=(( 
await(( #
_context(($ ,
.((, -
PaymentCards((- 9
.((9 :
AddAsync((: B
(((B C
paymentCard((C N
)((N O
;((O P
return)) 
entityEntry)) 
.)) 
Entity)) %
;))% &
}** 	
}-- 
}.. �
nD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\LevelRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class 
LevelRepository 
: 

Repository )
<) *
Level* /
>/ 0
,0 1
ILevelRepository2 B
{		 
private

 
readonly

  
ApplicationDbContext

 )
_context

* 2
;

2 3
public 

LevelRepository 
(  
ApplicationDbContext /
context0 7
)7 8
:9 :
base; ?
(? @
context@ G
)G H
{ 
_context 
= 
context 
; 
} 
public 

async 
Task 
< 
Level 
> 
GetLevelById )
() *
Guid* .
levelId/ 6
)6 7
{ 
return 
await 
_context 
. 
Levels $
.$ %
FirstOrDefaultAsync% 8
(8 9
x9 :
=>; =
x> ?
.? @
Id@ B
==C E
levelIdF M
)M N
;N O
} 
public 

void 
Update 
( 
Level 
level "
)" #
{ 
_context 
. 
Levels 
. 
Update 
( 
level $
)$ %
;% &
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (
Level( -
>- .
levels/ 5
)5 6
{ 
_context 
. 
Levels 
. 
UpdateRange #
(# $
levels$ *
)* +
;+ ,
} 
}   �
sD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\InstructorRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public		 
class		  
InstructorRepository		 !
:		" #

Repository		$ .
<		. /

Instructor		/ 9
>		9 :
,		: ;!
IInstructorRepository		< Q
{

 
private 
readonly  
ApplicationDbContext )
_context* 2
;2 3
public 
 
InstructorRepository 
(   
ApplicationDbContext  4
context5 <
)< =
:> ?
base@ D
(D E
contextE L
)L M
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 

Instructor !

instructor" ,
), -
{ 
_context 
. 
Instructors 
. 
Update #
(# $

instructor$ .
). /
;/ 0
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (

Instructor( 2
>2 3
instructors4 ?
)? @
{ 
_context 
. 
Instructors 
. 
UpdateRange (
(( )
instructors) 4
)4 5
;5 6
} 
public 

async 
Task 
< 

Instructor  
?  !
>! "
GetById# *
(* +
Guid+ /
id0 2
)2 3
{ 
return 
await 
_context 
. 
Instructors )
.) *
Include* 1
(1 2
$str2 C
)C D
.D E
FirstOrDefaultAsyncE X
(X Y
xY Z
=>[ ]
x^ _
._ `
InstructorId` l
==m o
idp r
)r s
;s t
} 
public   

async   
Task   
<   !
IDbContextTransaction   +
>  + ,!
BeginTransactionAsync  - B
(  B C
)  C D
{!! 
return"" 
await"" 
_context"" 
."" 
Database"" &
.""& '!
BeginTransactionAsync""' <
(""< =
)""= >
;""> ?
}## 
}$$ �
zD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\InstructorCommentRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class '
InstructorCommentRepository (
:) *

Repository+ 5
<5 6
InstructorComment6 G
>G H
,H I(
IInstructorCommentRepositoryJ f
{ 
private		 
readonly		  
ApplicationDbContext		 )
_context		* 2
;		2 3
public 
'
InstructorCommentRepository &
(& ' 
ApplicationDbContext' ;
context< C
)C D
:E F
baseG K
(K L
contextL S
)S T
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 
InstructorComment (
instructorComment) :
): ;
{ 
_context 
. 
InstructorComments #
.# $
Update$ *
(* +
instructorComment+ <
)< =
;= >
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (
InstructorComment( 9
>9 :
instructorComments; M
)M N
{ 
_context 
. 
InstructorComments #
.# $
UpdateRange$ /
(/ 0
instructorComments0 B
)B C
;C D
} 
} �

vD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\EmailTemplateRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class #
EmailTemplateRepository $
:% &

Repository' 1
<1 2
EmailTemplate2 ?
>? @
,@ A$
IEmailTemplateRepositoryB Z
{ 
private		 
readonly		  
ApplicationDbContext		 )
_context		* 2
;		2 3
public 
#
EmailTemplateRepository "
(" # 
ApplicationDbContext# 7
context8 ?
)? @
:A B
baseC G
(G H
contextH O
)O P
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 
EmailTemplate $
emailTemplate% 2
)2 3
{ 
_context 
. 
EmailTemplates 
.  
Update  &
(& '
emailTemplate' 4
)4 5
;5 6
} 
} �
zD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\IInstructorRatingRepository.cs
public 
class &
InstructorRatingRepository '
:( )

Repository* 4
<4 5
InstructorRating5 E
>E F
,F G'
IInstructorRatingRepositoryH c
{ 
private 
readonly  
ApplicationDbContext )
_context* 2
;2 3
public

 
&
InstructorRatingRepository

 %
(

% & 
ApplicationDbContext

& :
context

; B
)

B C
:

D E
base

F J
(

J K
context

K R
)

R S
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 
InstructorRating '
instructorRating( 8
)8 9
{ 
_context 
. 
InstructorRatings "
." #
Update# )
() *
instructorRating* :
): ;
;; <
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (
InstructorRating( 8
>8 9
instructorRatings: K
)K L
{ 
_context 
. 
InstructorRatings "
." #
UpdateRange# .
(. /
instructorRatings/ @
)@ A
;A B
} 
} �
|D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\CourseVersionStatusRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class )
CourseVersionStatusRepository *
:+ ,

Repository- 7
<7 8
CourseVersionStatus8 K
>K L
,L M*
ICourseVersionStatusRepositoryN l
{		 
private

 
readonly

  
ApplicationDbContext

 )
_context

* 2
;

2 3
public 
)
CourseVersionStatusRepository (
(( ) 
ApplicationDbContext) =
context> E
)E F
:G H
baseI M
(M N
contextN U
)U V
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 
CourseVersionStatus *
courseVersionStatus+ >
)> ?
{ 
_context 
. 
CourseVersionStatus $
.$ %
Update% +
(+ ,
courseVersionStatus, ?
)? @
;@ A
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (
CourseVersionStatus( ;
>; < 
courseVersionsStatus= Q
)Q R
{ 
_context 
. 
CourseVersionStatus $
.$ %
UpdateRange% 0
(0 1 
courseVersionsStatus1 E
)E F
;F G
} 
public 

async 
Task 
< 
CourseVersionStatus )
?) *
>* ++
GetCourseVersionStatusByIdAsync, K
(K L
GuidL P!
courseVersionStatusIdQ f
)f g
{ 
return 
await 
_context 
. 
CourseVersionStatus 1
.1 2
FirstOrDefaultAsync2 E
(E F
xF G
=>H J
xK L
.L M
IdM O
==P R!
courseVersionStatusIdS h
)h i
;i j
} 
} �
vD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\CourseVersionRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class #
CourseVersionRepository $
:% &

Repository' 1
<1 2
CourseVersion2 ?
>? @
,@ A$
ICourseVersionRepositoryB Z
{		 
private

 
readonly

  
ApplicationDbContext

 )
_context

* 2
;

2 3
public 
#
CourseVersionRepository "
(" # 
ApplicationDbContext# 7
context8 ?
)? @
:A B
baseC G
(G H
contextH O
)O P
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 
CourseVersion $
courseVersion% 2
)2 3
{ 
_context 
. 
CourseVersions 
.  
Update  &
(& '
courseVersion' 4
)4 5
;5 6
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (
CourseVersion( 5
>5 6
courseVersions7 E
)E F
{ 
_context 
. 
CourseVersions 
.  
UpdateRange  +
(+ ,
courseVersions, :
): ;
;; <
} 
public 

async 
Task 
< 
CourseVersion #
?# $
>$ %!
GetCourseVersionAsync& ;
( 
Guid 
courseVersionId 
, 
bool 
? 
asNoTracking 
= 
false "
) 
{   
return!! 
asNoTracking!! 
is!! 
not!! "
null!!# '
?"" 
await"" 
_context"" 
."" 
CourseVersions"" +
.## 
AsNoTracking## 
(## 
)## 
.$$ 
FirstOrDefaultAsync$$ $
($$$ %
x$$% &
=>$$' )
x$$* +
.$$+ ,
Id$$, .
==$$/ 1
courseVersionId$$2 A
)$$A B
:%% 
await%% 
_context%% 
.%% 
CourseVersions%% +
.&& 
FirstOrDefaultAsync&& $
(&&$ %
x&&% &
=>&&' )
x&&* +
.&&+ ,
Id&&, .
==&&/ 1
courseVersionId&&2 A
)&&A B
;&&B C
}'' 
public)) 

async)) 
Task)) 
<)) 
int)) 
>)) '
GetTotalCourseVersionsAsync)) 6
())6 7
Guid))7 ;
?)); <
courseId))= E
)))E F
{** 
return++ 
courseId++ 
is++ 
not++ 
null++ #
?,, 
await,, 
_context,, 
.,, 
CourseVersions,, +
.,,+ ,

CountAsync,,, 6
(,,6 7
x,,7 8
=>,,9 ;
x,,< =
.,,= >
CourseId,,> F
==,,G I
courseId,,J R
),,R S
:-- 
$num-- 
;-- 
}.. 
}// �
}D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\CourseVersionCommentRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class *
CourseVersionCommentRepository +
:, -

Repository. 8
<8 9 
CourseVersionComment9 M
>M N
,N O+
ICourseVersionCommentRepositoryP o
{		 
private

 
readonly

  
ApplicationDbContext

 )
_context

* 2
;

2 3
public 
*
CourseVersionCommentRepository )
() * 
ApplicationDbContext* >
context? F
)F G
:H I
baseJ N
(N O
contextO V
)V W
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
(  
CourseVersionComment + 
courseVersionComment, @
)@ A
{ 
_context 
. !
CourseVersionComments &
.& '
Update' -
(- . 
courseVersionComment. B
)B C
;C D
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' ( 
CourseVersionComment( <
>< =!
courseVersionComments> S
)S T
{ 
_context 
. !
CourseVersionComments &
.& '
UpdateRange' 2
(2 3!
courseVersionComments3 H
)H I
;I J
} 
public 

async 
Task 
<  
CourseVersionComment *
?* +
>+ ,'
GetCourseVersionCommentById- H
(H I
GuidI M"
courseversioncommentIdN d
)d e
{ 
return 
await 
_context 
. !
CourseVersionComments 3
.3 4
FirstOrDefaultAsync4 G
(G H
xH I
=>J L
xM N
.N O
IdO Q
==R T"
courseversioncommentIdU k
)k l
;l m
} 
} �
}D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\CourseSectionVersionRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class *
CourseSectionVersionRepository +
:, -

Repository. 8
<8 9 
CourseSectionVersion9 M
>M N
,N O+
ICourseSectionVersionRepositoryP o
{		 
private

 
readonly

  
ApplicationDbContext

 )
_context

* 2
;

2 3
public 
*
CourseSectionVersionRepository )
() * 
ApplicationDbContext* >
context? F
)F G
:H I
baseJ N
(N O
contextO V
)V W
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
(  
CourseSectionVersion + 
courseSectionVersion, @
)@ A
{ 
_context 
. !
CourseSectionVersions &
.& '
Update' -
(- . 
courseSectionVersion. B
)B C
;C D
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' ( 
CourseSectionVersion( <
>< =!
courseSectionVersions> S
)S T
{ 
_context 
. !
CourseSectionVersions &
.& '
UpdateRange' 2
(2 3!
courseSectionVersions3 H
)H I
;I J
} 
public 

async 
Task 
< 
List 
<  
CourseSectionVersion /
>/ 0
?0 1
>1 28
,GetCourseSectionVersionsOfCourseVersionAsync3 _
( 
Guid 
courseVersionId 
, 
bool 
? 
asNoTracking 
= 
false "
) 
{   
return!! 
asNoTracking!! 
is!! 
true!! #
?"" 
await"" 
_context"" 
."" !
CourseSectionVersions"" 2
.## 
AsNoTracking## 
(## 
)## 
.$$ 
Where$$ 
($$ 
x$$ 
=>$$ 
x$$ 
.$$ 
CourseVersionId$$ -
==$$. 0
courseVersionId$$1 @
)$$@ A
.%% 
ToListAsync%% 
(%% 
)%% 
:&& 
await&& 
_context&& 
.&& !
CourseSectionVersions&& 2
.'' 
Where'' 
('' 
x'' 
=>'' 
x'' 
.'' 
CourseVersionId'' -
==''. 0
courseVersionId''1 @
)''@ A
.(( 
ToListAsync(( 
((( 
)(( 
;(( 
})) 
}** �
oD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\CourseRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
{ 
public 

class 
CourseRepository !
:" #

Repository$ .
<. /
Course/ 5
>5 6
,6 7
ICourseRepository8 I
{		 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
public 
CourseRepository 
(   
ApplicationDbContext  4
context5 <
)< =
:> ?
base@ D
(D E
contextE L
)L M
{ 	
_context 
= 
context 
; 
} 	
public 
void 
Update 
( 
Course !
course" (
)( )
{ 	
_context 
. 
Courses 
. 
Update #
(# $
course$ *
)* +
;+ ,
} 	
public 
void 
UpdateRange 
(  
IEnumerable  +
<+ ,
Course, 2
>2 3
courses4 ;
); <
{ 	
_context 
. 
Courses 
. 
UpdateRange (
(( )
courses) 0
)0 1
;1 2
} 	
} 
} �
qD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Repository\CategoryRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Repository  *
;* +
public 
class 
CategoryRepository 
:  

Repository! +
<+ ,
Category, 4
>4 5
,5 6
ICategoryRepository7 J
{		 
private 
readonly  
ApplicationDbContext )
_context* 2
;2 3
public 

CategoryRepository 
(  
ApplicationDbContext 2
context3 :
): ;
:< =
base> B
(B C
contextC J
)J K
{ 
_context 
= 
context 
; 
} 
public 

void 
Update 
( 
Category 
category  (
)( )
{ 
_context 
. 

Categories 
. 
Update "
(" #
category# +
)+ ,
;, -
} 
public 

void 
UpdateRange 
( 
IEnumerable '
<' (
Category( 0
>0 1

categories2 <
)< =
{ 
_context 
. 

Categories 
. 
UpdateRange '
(' (

categories( 2
)2 3
;3 4
} 
public 

async 
Task 
< 
Category 
>  
GetCategoryByIdAsync  4
(4 5
Guid5 9
id: <
)< =
{ 
return 
await 
_context 
. 

Categories (
.( )
FirstOrDefaultAsync) <
(< =
c= >
=>? A
cB C
.C D
IdD F
==G I
idJ L
)L M
;M N
} 
} ��
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240705052116_AddMoreColumnForLevelTable.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{		 
public 

partial 
class &
AddMoreColumnForLevelTable 3
:4 5
	Migration6 ?
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 

DeleteData '
(' (
table 
: 
$str '
,' (
	keyColumn 
: 
$str 
,  
keyValue 
: 
new 
Guid "
(" #
$str# I
)I J
)J K
;K L
migrationBuilder 
. 

DeleteData '
(' (
table 
: 
$str '
,' (
	keyColumn 
: 
$str 
,  
keyValue 
: 
new 
Guid "
(" #
$str# I
)I J
)J K
;K L
migrationBuilder 
. 

DeleteData '
(' (
table 
: 
$str '
,' (
	keyColumn 
: 
$str 
,  
keyValue 
: 
new 
Guid "
(" #
$str# I
)I J
)J K
;K L
migrationBuilder 
. 

DeleteData '
(' (
table   
:   
$str   '
,  ' (
	keyColumn!! 
:!! 
$str!! 
,!!  
keyValue"" 
:"" 
new"" 
Guid"" "
(""" #
$str""# I
)""I J
)""J K
;""K L
migrationBuilder$$ 
.$$ 

DeleteData$$ '
($$' (
table%% 
:%% 
$str%% '
,%%' (
	keyColumn&& 
:&& 
$str&& 
,&&  
keyValue'' 
:'' 
new'' 
Guid'' "
(''" #
$str''# I
)''I J
)''J K
;''K L
migrationBuilder)) 
.)) 

DeleteData)) '
())' (
table** 
:** 
$str** '
,**' (
	keyColumn++ 
:++ 
$str++ 
,++  
keyValue,, 
:,, 
new,, 
Guid,, "
(,," #
$str,,# I
),,I J
),,J K
;,,K L
migrationBuilder.. 
... 

DeleteData.. '
(..' (
table// 
:// 
$str// '
,//' (
	keyColumn00 
:00 
$str00 
,00  
keyValue11 
:11 
new11 
Guid11 "
(11" #
$str11# I
)11I J
)11J K
;11K L
migrationBuilder33 
.33 

DeleteData33 '
(33' (
table44 
:44 
$str44 '
,44' (
	keyColumn55 
:55 
$str55 
,55  
keyValue66 
:66 
new66 
Guid66 "
(66" #
$str66# I
)66I J
)66J K
;66K L
migrationBuilder88 
.88 

DeleteData88 '
(88' (
table99 
:99 
$str99 '
,99' (
	keyColumn:: 
::: 
$str:: 
,::  
keyValue;; 
:;; 
new;; 
Guid;; "
(;;" #
$str;;# I
);;I J
);;J K
;;;K L
migrationBuilder== 
.== 
	AddColumn== &
<==& '
string==' -
>==- .
(==. /
name>> 
:>> 
$str>>  
,>>  !
table?? 
:?? 
$str?? 
,??  
type@@ 
:@@ 
$str@@ %
,@@% &
nullableAA 
:AA 
trueAA 
)AA 
;AA  
migrationBuilderCC 
.CC 
	AddColumnCC &
<CC& '
DateTimeCC' /
>CC/ 0
(CC0 1
nameDD 
:DD 
$strDD "
,DD" #
tableEE 
:EE 
$strEE 
,EE  
typeFF 
:FF 
$strFF !
,FF! "
nullableGG 
:GG 
trueGG 
)GG 
;GG  
migrationBuilderII 
.II 
	AddColumnII &
<II& '
intII' *
>II* +
(II+ ,
nameJJ 
:JJ 
$strJJ 
,JJ 
tableKK 
:KK 
$strKK 
,KK  
typeLL 
:LL 
$strLL 
,LL 
nullableMM 
:MM 
falseMM 
,MM  
defaultValueNN 
:NN 
$numNN 
)NN  
;NN  !
migrationBuilderPP 
.PP 
	AddColumnPP &
<PP& '
stringPP' -
>PP- .
(PP. /
nameQQ 
:QQ 
$strQQ  
,QQ  !
tableRR 
:RR 
$strRR 
,RR  
typeSS 
:SS 
$strSS %
,SS% &
nullableTT 
:TT 
trueTT 
)TT 
;TT  
migrationBuilderVV 
.VV 
	AddColumnVV &
<VV& '
DateTimeVV' /
>VV/ 0
(VV0 1
nameWW 
:WW 
$strWW "
,WW" #
tableXX 
:XX 
$strXX 
,XX  
typeYY 
:YY 
$strYY !
,YY! "
nullableZZ 
:ZZ 
trueZZ 
)ZZ 
;ZZ  
migrationBuilder\\ 
.\\ 

UpdateData\\ '
(\\' (
table]] 
:]] 
$str]] $
,]]$ %
	keyColumn^^ 
:^^ 
$str^^ 
,^^  
keyValue__ 
:__ 
$str__ +
,__+ ,
columns`` 
:`` 
new`` 
[`` 
]`` 
{``  
$str``! 3
,``3 4
$str``5 A
,``A B
$str``C Q
,``Q R
$str``S b
}``c d
,``d e
valuesaa 
:aa 
newaa 
objectaa "
[aa" #
]aa# $
{aa% &
$straa' M
,aaM N
newaaO R
DateTimeaaS [
(aa[ \
$numaa\ `
,aa` a
$numaab c
,aac d
$numaae f
,aaf g
$numaah i
,aai j
$numaak m
,aam n
$numaao q
,aaq r
$numaas v
,aav w
DateTimeKind	aax �
.
aa� �
Utc
aa� �
)
aa� �
.
aa� �
AddTicks
aa� �
(
aa� �
$num
aa� �
)
aa� �
,
aa� �
$str
aa� �
,
aa� �
$str
aa� �
}
aa� �
)
aa� �
;
aa� �
migrationBuildercc 
.cc 

InsertDatacc '
(cc' (
tabledd 
:dd 
$strdd '
,dd' (
columnsee 
:ee 
newee 
[ee 
]ee 
{ee  
$stree! %
,ee% &
$stree' 4
,ee4 5
$stree6 D
,eeD E
$streeF P
,eeP Q
$streeR \
,ee\ ]
$stree^ j
,eej k
$streel {
,ee{ |
$str	ee} �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
}
ee� �
,
ee� �
valuesff 
:ff 
newff 
objectff "
[ff" #
,ff# $
]ff$ %
{gg 
{hh 
newhh 
Guidhh 
(hh 
$strhh E
)hhE F
,hhF G
$str	hhH �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
new
hh� �
DateTime
hh� �
(
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
DateTimeKind
hh� �
.
hh� �
Local
hh� �
)
hh� �
.
hh� �
AddTicks
hh� �
(
hh� �
$num
hh� �
)
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
$num
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
$str
hh� �
,
hh� �
new
hh� �
DateTime
hh� �
(
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
$num
hh� �
,
hh� �
DateTimeKind
hh� �
.
hh� �
Local
hh� �
)
hh� �
.
hh� �
AddTicks
hh� �
(
hh� �
$num
hh� �
)
hh� �
}
hh� �
,
hh� �
{ii 
newii 
Guidii 
(ii 
$strii E
)iiE F
,iiF G
$str	iiH �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
new
ii� �
DateTime
ii� �
(
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
DateTimeKind
ii� �
.
ii� �
Local
ii� �
)
ii� �
.
ii� �
AddTicks
ii� �
(
ii� �
$num
ii� �
)
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
$num
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
$str
ii� �
,
ii� �
new
ii� �
DateTime
ii� �
(
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
$num
ii� �
,
ii� �
DateTimeKind
ii� �
.
ii� �
Local
ii� �
)
ii� �
.
ii� �
AddTicks
ii� �
(
ii� �
$num
ii� �
)
ii� �
}
ii� �
,
ii� �
{jj 
newjj 
Guidjj 
(jj 
$strjj E
)jjE F
,jjF G
$strjjH s
,jjs t
$str	jju �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
new
jj� �
DateTime
jj� �
(
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
DateTimeKind
jj� �
.
jj� �
Local
jj� �
)
jj� �
.
jj� �
AddTicks
jj� �
(
jj� �
$num
jj� �
)
jj� �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
$num
jj� �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
$str
jj� �
,
jj� �
new
jj� �
DateTime
jj� �
(
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
$num
jj� �
,
jj� �
DateTimeKind
jj� �
.
jj� �
Local
jj� �
)
jj� �
.
jj� �
AddTicks
jj� �
(
jj� �
$num
jj� �
)
jj� �
}
jj� �
,
jj� �
{kk 
newkk 
Guidkk 
(kk 
$strkk E
)kkE F
,kkF G
$str	kkH �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
new
kk� �
DateTime
kk� �
(
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
DateTimeKind
kk� �
.
kk� �
Local
kk� �
)
kk� �
.
kk� �
AddTicks
kk� �
(
kk� �
$num
kk� �
)
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
$num
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
$str
kk� �
,
kk� �
new
kk� �
DateTime
kk� �
(
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
$num
kk� �
,
kk� �
DateTimeKind
kk� �
.
kk� �
Local
kk� �
)
kk� �
.
kk� �
AddTicks
kk� �
(
kk� �
$num
kk� �
)
kk� �
}
kk� �
,
kk� �
{ll 
newll 
Guidll 
(ll 
$strll E
)llE F
,llF G
$str	llH �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
new
ll� �
DateTime
ll� �
(
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
DateTimeKind
ll� �
.
ll� �
Local
ll� �
)
ll� �
.
ll� �
AddTicks
ll� �
(
ll� �
$num
ll� �
)
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
$num
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
$str
ll� �
,
ll� �
new
ll� �
DateTime
ll� �
(
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
$num
ll� �
,
ll� �
DateTimeKind
ll� �
.
ll� �
Local
ll� �
)
ll� �
.
ll� �
AddTicks
ll� �
(
ll� �
$num
ll� �
)
ll� �
}
ll� �
,
ll� �
{mm 
newmm 
Guidmm 
(mm 
$strmm E
)mmE F
,mmF G
$str	mmH �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
new
mm� �
DateTime
mm� �
(
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
DateTimeKind
mm� �
.
mm� �
Local
mm� �
)
mm� �
.
mm� �
AddTicks
mm� �
(
mm� �
$num
mm� �
)
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
$num
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
$str
mm� �
,
mm� �
new
mm� �
DateTime
mm� �
(
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
$num
mm� �
,
mm� �
DateTimeKind
mm� �
.
mm� �
Local
mm� �
)
mm� �
.
mm� �
AddTicks
mm� �
(
mm� �
$num
mm� �
)
mm� �
}
mm� �
,
mm� �
{nn 
newnn 
Guidnn 
(nn 
$strnn E
)nnE F
,nnF G
$str	nnH �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
new
nn� �
DateTime
nn� �
(
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
DateTimeKind
nn� �
.
nn� �
Local
nn� �
)
nn� �
.
nn� �
AddTicks
nn� �
(
nn� �
$num
nn� �
)
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
$num
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
$str
nn� �
,
nn� �
new
nn� �
DateTime
nn� �
(
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
$num
nn� �
,
nn� �
DateTimeKind
nn� �
.
nn� �
Local
nn� �
)
nn� �
.
nn� �
AddTicks
nn� �
(
nn� �
$num
nn� �
)
nn� �
}
nn� �
,
nn� �
{oo 
newoo 
Guidoo 
(oo 
$stroo E
)ooE F
,ooF G
$str	ooH �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
new
oo� �
DateTime
oo� �
(
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
DateTimeKind
oo� �
.
oo� �
Local
oo� �
)
oo� �
.
oo� �
AddTicks
oo� �
(
oo� �
$num
oo� �
)
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
$num
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
$str
oo� �
,
oo� �
new
oo� �
DateTime
oo� �
(
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
$num
oo� �
,
oo� �
DateTimeKind
oo� �
.
oo� �
Local
oo� �
)
oo� �
.
oo� �
AddTicks
oo� �
(
oo� �
$num
oo� �
)
oo� �
}
oo� �
,
oo� �
{pp 
newpp 
Guidpp 
(pp 
$strpp E
)ppE F
,ppF G
$str	ppH �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
new
pp� �
DateTime
pp� �
(
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
DateTimeKind
pp� �
.
pp� �
Local
pp� �
)
pp� �
.
pp� �
AddTicks
pp� �
(
pp� �
$num
pp� �
)
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
$num
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
$str
pp� �
,
pp� �
new
pp� �
DateTime
pp� �
(
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
$num
pp� �
,
pp� �
DateTimeKind
pp� �
.
pp� �
Local
pp� �
)
pp� �
.
pp� �
AddTicks
pp� �
(
pp� �
$num
pp� �
)
pp� �
}
pp� �
}qq 
)qq 
;qq 
}rr 	
	protecteduu 
overrideuu 
voiduu 
Downuu  $
(uu$ %
MigrationBuilderuu% 5
migrationBuilderuu6 F
)uuF G
{vv 	
migrationBuilderww 
.ww 

DeleteDataww '
(ww' (
tablexx 
:xx 
$strxx '
,xx' (
	keyColumnyy 
:yy 
$stryy 
,yy  
keyValuezz 
:zz 
newzz 
Guidzz "
(zz" #
$strzz# I
)zzI J
)zzJ K
;zzK L
migrationBuilder|| 
.|| 

DeleteData|| '
(||' (
table}} 
:}} 
$str}} '
,}}' (
	keyColumn~~ 
:~~ 
$str~~ 
,~~  
keyValue 
: 
new 
Guid "
(" #
$str# I
)I J
)J K
;K L
migrationBuilder
�� 
.
�� 

DeleteData
�� '
(
��' (
table
�� 
:
�� 
$str
�� '
,
��' (
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
)
��J K
;
��K L
migrationBuilder
�� 
.
�� 

DeleteData
�� '
(
��' (
table
�� 
:
�� 
$str
�� '
,
��' (
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
)
��J K
;
��K L
migrationBuilder
�� 
.
�� 

DeleteData
�� '
(
��' (
table
�� 
:
�� 
$str
�� '
,
��' (
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
)
��J K
;
��K L
migrationBuilder
�� 
.
�� 

DeleteData
�� '
(
��' (
table
�� 
:
�� 
$str
�� '
,
��' (
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
)
��J K
;
��K L
migrationBuilder
�� 
.
�� 

DeleteData
�� '
(
��' (
table
�� 
:
�� 
$str
�� '
,
��' (
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
)
��J K
;
��K L
migrationBuilder
�� 
.
�� 

DeleteData
�� '
(
��' (
table
�� 
:
�� 
$str
�� '
,
��' (
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
)
��J K
;
��K L
migrationBuilder
�� 
.
�� 

DeleteData
�� '
(
��' (
table
�� 
:
�� 
$str
�� '
,
��' (
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
new
�� 
Guid
�� "
(
��" #
$str
��# I
)
��I J
)
��J K
;
��K L
migrationBuilder
�� 
.
�� 

DropColumn
�� '
(
��' (
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� 
)
��  
;
��  !
migrationBuilder
�� 
.
�� 

DropColumn
�� '
(
��' (
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� 
)
��  
;
��  !
migrationBuilder
�� 
.
�� 

DropColumn
�� '
(
��' (
name
�� 
:
�� 
$str
�� 
,
�� 
table
�� 
:
�� 
$str
�� 
)
��  
;
��  !
migrationBuilder
�� 
.
�� 

DropColumn
�� '
(
��' (
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� 
)
��  
;
��  !
migrationBuilder
�� 
.
�� 

DropColumn
�� '
(
��' (
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� 
)
��  
;
��  !
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� $
,
��$ %
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
$str
�� +
,
��+ ,
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! 3
,
��3 4
$str
��5 A
,
��A B
$str
��C Q
,
��Q R
$str
��S b
}
��c d
,
��d e
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
]
��# $
{
��% &
$str
��' M
,
��M N
new
��O R
DateTime
��S [
(
��[ \
$num
��\ `
,
��` a
$num
��b c
,
��c d
$num
��e f
,
��f g
$num
��h j
,
��j k
$num
��l n
,
��n o
$num
��p r
,
��r s
$num
��t w
,
��w x
DateTimeKind��y �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
)��� �
;��� �
migrationBuilder
�� 
.
�� 

InsertData
�� '
(
��' (
table
�� 
:
�� 
$str
�� '
,
��' (
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! %
,
��% &
$str
��' 4
,
��4 5
$str
��6 D
,
��D E
$str
��F P
,
��P Q
$str
��R \
,
��\ ]
$str
��^ j
,
��j k
$str
��l {
,
��{ |
$str��} �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
,��� �
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
,
��# $
]
��$ %
{
�� 
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str��H �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str��H �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str��H �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str
��H s
,
��s t
$str��u �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str��H �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str��H �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str��H �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str��H �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
,��� �
{
�� 
new
�� 
Guid
�� 
(
�� 
$str
�� E
)
��E F
,
��F G
$str��H �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$num��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
$str��� �
,��� �
new��� �
DateTime��� �
(��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
DateTimeKind��� �
.��� �
Local��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
}��� �
}
�� 
)
�� 
;
�� 
}
�� 	
}
�� 
}�� ��
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240704123625_ModifiedDataSeeding.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{		 
public 

partial 
class 
ModifiedDataSeeding ,
:- .
	Migration/ 8
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 

UpdateData '
(' (
table 
: 
$str $
,$ %
	keyColumn 
: 
$str 
,  
keyValue 
: 
$str +
,+ ,
columns 
: 
new 
[ 
] 
{  
$str! 3
,3 4
$str5 A
,A B
$strC Q
,Q R
$strS b
}c d
,d e
values 
: 
new 
object "
[" #
]# $
{% &
$str' M
,M N
newO R
DateTimeS [
([ \
$num\ `
,` a
$numb c
,c d
$nume f
,f g
$numh j
,j k
$numl n
,n o
$nump r
,r s
$numt w
,w x
DateTimeKind	y �
.
� �
Utc
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
,
� �
$str
� �
,
� �
$str
� �
}
� �
)
� �
;
� �
migrationBuilder 
. 

InsertData '
(' (
table 
: 
$str '
,' (
columns 
: 
new 
[ 
] 
{  
$str! %
,% &
$str' 4
,4 5
$str6 D
,D E
$strF P
,P Q
$strR \
,\ ]
$str^ j
,j k
$strl {
,{ |
$str	} �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
}
� �
,
� �
values 
: 
new 
object "
[" #
,# $
]$ %
{ 
{ 
new 
Guid 
( 
$str E
)E F
,F G
$str	H �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Local
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$num
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Local
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
}
� �
,
� �
{ 
new 
Guid 
( 
$str E
)E F
,F G
$str	H �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Local
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$num
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Local
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
}
� �
,
� �
{ 
new 
Guid 
( 
$str E
)E F
,F G
$str	H �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Local
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$num
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Local
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
}
� �
,
� �
{ 
new 
Guid 
( 
$str E
)E F
,F G
$strH s
,s t
$str	u �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Local
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$num
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Local
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
}
� �
,
� �
{   
new   
Guid   
(   
$str   E
)  E F
,  F G
$str	  H �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
new
  � �
DateTime
  � �
(
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
DateTimeKind
  � �
.
  � �
Local
  � �
)
  � �
.
  � �
AddTicks
  � �
(
  � �
$num
  � �
)
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
$num
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
$str
  � �
,
  � �
new
  � �
DateTime
  � �
(
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
$num
  � �
,
  � �
DateTimeKind
  � �
.
  � �
Local
  � �
)
  � �
.
  � �
AddTicks
  � �
(
  � �
$num
  � �
)
  � �
}
  � �
,
  � �
{!! 
new!! 
Guid!! 
(!! 
$str!! E
)!!E F
,!!F G
$str	!!H �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
new
!!� �
DateTime
!!� �
(
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
DateTimeKind
!!� �
.
!!� �
Local
!!� �
)
!!� �
.
!!� �
AddTicks
!!� �
(
!!� �
$num
!!� �
)
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
$num
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
$str
!!� �
,
!!� �
new
!!� �
DateTime
!!� �
(
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
$num
!!� �
,
!!� �
DateTimeKind
!!� �
.
!!� �
Local
!!� �
)
!!� �
.
!!� �
AddTicks
!!� �
(
!!� �
$num
!!� �
)
!!� �
}
!!� �
,
!!� �
{"" 
new"" 
Guid"" 
("" 
$str"" E
)""E F
,""F G
$str	""H �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
new
""� �
DateTime
""� �
(
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
DateTimeKind
""� �
.
""� �
Local
""� �
)
""� �
.
""� �
AddTicks
""� �
(
""� �
$num
""� �
)
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
$num
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
$str
""� �
,
""� �
new
""� �
DateTime
""� �
(
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
$num
""� �
,
""� �
DateTimeKind
""� �
.
""� �
Local
""� �
)
""� �
.
""� �
AddTicks
""� �
(
""� �
$num
""� �
)
""� �
}
""� �
,
""� �
{## 
new## 
Guid## 
(## 
$str## E
)##E F
,##F G
$str	##H �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
new
##� �
DateTime
##� �
(
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
DateTimeKind
##� �
.
##� �
Local
##� �
)
##� �
.
##� �
AddTicks
##� �
(
##� �
$num
##� �
)
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
$num
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
$str
##� �
,
##� �
new
##� �
DateTime
##� �
(
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
$num
##� �
,
##� �
DateTimeKind
##� �
.
##� �
Local
##� �
)
##� �
.
##� �
AddTicks
##� �
(
##� �
$num
##� �
)
##� �
}
##� �
,
##� �
{$$ 
new$$ 
Guid$$ 
($$ 
$str$$ E
)$$E F
,$$F G
$str	$$H �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
new
$$� �
DateTime
$$� �
(
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
DateTimeKind
$$� �
.
$$� �
Local
$$� �
)
$$� �
.
$$� �
AddTicks
$$� �
(
$$� �
$num
$$� �
)
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
$num
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
$str
$$� �
,
$$� �
new
$$� �
DateTime
$$� �
(
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
$num
$$� �
,
$$� �
DateTimeKind
$$� �
.
$$� �
Local
$$� �
)
$$� �
.
$$� �
AddTicks
$$� �
(
$$� �
$num
$$� �
)
$$� �
}
$$� �
}%% 
)%% 
;%% 
}&& 	
	protected)) 
override)) 
void)) 
Down))  $
())$ %
MigrationBuilder))% 5
migrationBuilder))6 F
)))F G
{** 	
migrationBuilder++ 
.++ 

DeleteData++ '
(++' (
table,, 
:,, 
$str,, '
,,,' (
	keyColumn-- 
:-- 
$str-- 
,--  
keyValue.. 
:.. 
new.. 
Guid.. "
(.." #
$str..# I
)..I J
)..J K
;..K L
migrationBuilder00 
.00 

DeleteData00 '
(00' (
table11 
:11 
$str11 '
,11' (
	keyColumn22 
:22 
$str22 
,22  
keyValue33 
:33 
new33 
Guid33 "
(33" #
$str33# I
)33I J
)33J K
;33K L
migrationBuilder55 
.55 

DeleteData55 '
(55' (
table66 
:66 
$str66 '
,66' (
	keyColumn77 
:77 
$str77 
,77  
keyValue88 
:88 
new88 
Guid88 "
(88" #
$str88# I
)88I J
)88J K
;88K L
migrationBuilder:: 
.:: 

DeleteData:: '
(::' (
table;; 
:;; 
$str;; '
,;;' (
	keyColumn<< 
:<< 
$str<< 
,<<  
keyValue== 
:== 
new== 
Guid== "
(==" #
$str==# I
)==I J
)==J K
;==K L
migrationBuilder?? 
.?? 

DeleteData?? '
(??' (
table@@ 
:@@ 
$str@@ '
,@@' (
	keyColumnAA 
:AA 
$strAA 
,AA  
keyValueBB 
:BB 
newBB 
GuidBB "
(BB" #
$strBB# I
)BBI J
)BBJ K
;BBK L
migrationBuilderDD 
.DD 

DeleteDataDD '
(DD' (
tableEE 
:EE 
$strEE '
,EE' (
	keyColumnFF 
:FF 
$strFF 
,FF  
keyValueGG 
:GG 
newGG 
GuidGG "
(GG" #
$strGG# I
)GGI J
)GGJ K
;GGK L
migrationBuilderII 
.II 

DeleteDataII '
(II' (
tableJJ 
:JJ 
$strJJ '
,JJ' (
	keyColumnKK 
:KK 
$strKK 
,KK  
keyValueLL 
:LL 
newLL 
GuidLL "
(LL" #
$strLL# I
)LLI J
)LLJ K
;LLK L
migrationBuilderNN 
.NN 

DeleteDataNN '
(NN' (
tableOO 
:OO 
$strOO '
,OO' (
	keyColumnPP 
:PP 
$strPP 
,PP  
keyValueQQ 
:QQ 
newQQ 
GuidQQ "
(QQ" #
$strQQ# I
)QQI J
)QQJ K
;QQK L
migrationBuilderSS 
.SS 

DeleteDataSS '
(SS' (
tableTT 
:TT 
$strTT '
,TT' (
	keyColumnUU 
:UU 
$strUU 
,UU  
keyValueVV 
:VV 
newVV 
GuidVV "
(VV" #
$strVV# I
)VVI J
)VVJ K
;VVK L
migrationBuilderXX 
.XX 

UpdateDataXX '
(XX' (
tableYY 
:YY 
$strYY $
,YY$ %
	keyColumnZZ 
:ZZ 
$strZZ 
,ZZ  
keyValue[[ 
:[[ 
$str[[ +
,[[+ ,
columns\\ 
:\\ 
new\\ 
[\\ 
]\\ 
{\\  
$str\\! 3
,\\3 4
$str\\5 A
,\\A B
$str\\C Q
,\\Q R
$str\\S b
}\\c d
,\\d e
values]] 
:]] 
new]] 
object]] "
[]]" #
]]]# $
{]]% &
$str]]' M
,]]M N
new]]O R
DateTime]]S [
(]][ \
$num]]\ `
,]]` a
$num]]b c
,]]c d
$num]]e f
,]]f g
$num]]h i
,]]i j
$num]]k m
,]]m n
$num]]o q
,]]q r
$num]]s v
,]]v w
DateTimeKind	]]x �
.
]]� �
Utc
]]� �
)
]]� �
.
]]� �
AddTicks
]]� �
(
]]� �
$num
]]� �
)
]]� �
,
]]� �
$str
]]� �
,
]]� �
$str
]]� �
}
]]� �
)
]]� �
;
]]� �
}^^ 	
}__ 
}`` �$
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240701055338_RenameSomePropInCourse.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 "
RenameSomePropInCourse		 /
:		0 1
	Migration		2 ;
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
RenameColumn )
() *
name 
: 
$str #
,# $
table 
: 
$str  
,  !
newName 
: 
$str '
)' (
;( )
migrationBuilder 
. 
RenameColumn )
() *
name 
: 
$str %
,% &
table 
: 
$str  
,  !
newName 
: 
$str *
)* +
;+ ,
migrationBuilder 
. 

UpdateData '
(' (
table 
: 
$str $
,$ %
	keyColumn 
: 
$str 
,  
keyValue 
: 
$str +
,+ ,
columns 
: 
new 
[ 
] 
{  
$str! 3
,3 4
$str5 A
,A B
$strC Q
,Q R
$strS b
}c d
,d e
values 
: 
new 
object "
[" #
]# $
{% &
$str' M
,M N
newO R
DateTimeS [
([ \
$num\ `
,` a
$numb c
,c d
$nume f
,f g
$numh i
,i j
$numk m
,m n
$numo q
,q r
$nums v
,v w
DateTimeKind	x �
.
� �
Utc
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
,
� �
$str
� �
,
� �
$str
� �
}
� �
)
� �
;
� �
} 	
	protected!! 
override!! 
void!! 
Down!!  $
(!!$ %
MigrationBuilder!!% 5
migrationBuilder!!6 F
)!!F G
{"" 	
migrationBuilder## 
.## 
RenameColumn## )
(##) *
name$$ 
:$$ 
$str$$ $
,$$$ %
table%% 
:%% 
$str%%  
,%%  !
newName&& 
:&& 
$str&& &
)&&& '
;&&' (
migrationBuilder(( 
.(( 
RenameColumn(( )
((() *
name)) 
:)) 
$str)) '
,))' (
table** 
:** 
$str**  
,**  !
newName++ 
:++ 
$str++ (
)++( )
;++) *
migrationBuilder-- 
.-- 

UpdateData-- '
(--' (
table.. 
:.. 
$str.. $
,..$ %
	keyColumn// 
:// 
$str// 
,//  
keyValue00 
:00 
$str00 +
,00+ ,
columns11 
:11 
new11 
[11 
]11 
{11  
$str11! 3
,113 4
$str115 A
,11A B
$str11C Q
,11Q R
$str11S b
}11c d
,11d e
values22 
:22 
new22 
object22 "
[22" #
]22# $
{22% &
$str22' M
,22M N
new22O R
DateTime22S [
(22[ \
$num22\ `
,22` a
$num22b c
,22c d
$num22e f
,22f g
$num22h i
,22i j
$num22k m
,22m n
$num22o q
,22q r
$num22s v
,22v w
DateTimeKind	22x �
.
22� �
Utc
22� �
)
22� �
.
22� �
AddTicks
22� �
(
22� �
$num
22� �
)
22� �
,
22� �
$str
22� �
,
22� �
$str
22� �
}
22� �
)
22� �
;
22� �
}33 	
}44 
}55 �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240701054917_ModifiedCourseAndCourseVersion.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 *
ModifiedCourseAndCourseVersion		 7
:		8 9
	Migration		: C
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str 8
,8 9
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str 1
,1 2
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str &
)& '
;' (
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str &
)& '
;' (
migrationBuilder 
. 
	DropIndex &
(& '
name 
: 
$str -
,- .
table 
: 
$str  
)  !
;! "
migrationBuilder   
.   
	DropIndex   &
(  & '
name!! 
:!! 
$str!! *
,!!* +
table"" 
:"" 
$str""  
)""  !
;""! "
migrationBuilder$$ 
.$$ 

DropColumn$$ '
($$' (
name%% 
:%% 
$str%% "
,%%" #
table&& 
:&& 
$str&&  
)&&  !
;&&! "
migrationBuilder(( 
.(( 

DropColumn(( '
(((' (
name)) 
:)) 
$str)) $
,))$ %
table** 
:** 
$str**  
)**  !
;**! "
migrationBuilder,, 
.,, 

DropColumn,, '
(,,' (
name-- 
:-- 
$str-- #
,--# $
table.. 
:.. 
$str..  
)..  !
;..! "
migrationBuilder00 
.00 

DropColumn00 '
(00' (
name11 
:11 
$str11 $
,11$ %
table22 
:22 
$str22  
)22  !
;22! "
migrationBuilder44 
.44 

DropColumn44 '
(44' (
name55 
:55 
$str55  
,55  !
table66 
:66 
$str66  
)66  !
;66! "
migrationBuilder88 
.88 

DropColumn88 '
(88' (
name99 
:99 
$str99 
,99 
table:: 
::: 
$str::  
)::  !
;::! "
migrationBuilder<< 
.<< 

DropColumn<< '
(<<' (
name== 
:== 
$str== 
,== 
table>> 
:>> 
$str>>  
)>>  !
;>>! "
migrationBuilder@@ 
.@@ 
RenameColumn@@ )
(@@) *
nameAA 
:AA 
$strAA 
,AA  
tableBB 
:BB 
$strBB  
,BB  !
newNameCC 
:CC 
$strCC (
)CC( )
;CC) *
migrationBuilderEE 
.EE 

UpdateDataEE '
(EE' (
tableFF 
:FF 
$strFF $
,FF$ %
	keyColumnGG 
:GG 
$strGG 
,GG  
keyValueHH 
:HH 
$strHH +
,HH+ ,
columnsII 
:II 
newII 
[II 
]II 
{II  
$strII! 3
,II3 4
$strII5 A
,IIA B
$strIIC Q
,IIQ R
$strIIS b
}IIc d
,IId e
valuesJJ 
:JJ 
newJJ 
objectJJ "
[JJ" #
]JJ# $
{JJ% &
$strJJ' M
,JJM N
newJJO R
DateTimeJJS [
(JJ[ \
$numJJ\ `
,JJ` a
$numJJb c
,JJc d
$numJJe f
,JJf g
$numJJh i
,JJi j
$numJJk m
,JJm n
$numJJo q
,JJq r
$numJJs v
,JJv w
DateTimeKind	JJx �
.
JJ� �
Utc
JJ� �
)
JJ� �
.
JJ� �
AddTicks
JJ� �
(
JJ� �
$num
JJ� �
)
JJ� �
,
JJ� �
$str
JJ� �
,
JJ� �
$str
JJ� �
}
JJ� �
)
JJ� �
;
JJ� �
migrationBuilderLL 
.LL 
CreateIndexLL (
(LL( )
nameMM 
:MM 
$strMM 4
,MM4 5
tableNN 
:NN 
$strNN '
,NN' (
columnOO 
:OO 
$strOO $
)OO$ %
;OO% &
migrationBuilderQQ 
.QQ 
CreateIndexQQ (
(QQ( )
nameRR 
:RR 
$strRR 1
,RR1 2
tableSS 
:SS 
$strSS '
,SS' (
columnTT 
:TT 
$strTT !
)TT! "
;TT" #
migrationBuilderVV 
.VV 
AddForeignKeyVV *
(VV* +
nameWW 
:WW 
$strWW ?
,WW? @
tableXX 
:XX 
$strXX '
,XX' (
columnYY 
:YY 
$strYY $
,YY$ %
principalTableZZ 
:ZZ 
$strZZ  ,
,ZZ, -
principalColumn[[ 
:[[  
$str[[! %
)[[% &
;[[& '
migrationBuilder]] 
.]] 
AddForeignKey]] *
(]]* +
name^^ 
:^^ 
$str^^ 8
,^^8 9
table__ 
:__ 
$str__ '
,__' (
column`` 
:`` 
$str`` !
,``! "
principalTableaa 
:aa 
$straa  (
,aa( )
principalColumnbb 
:bb  
$strbb! %
)bb% &
;bb& '
}cc 	
	protectedff 
overrideff 
voidff 
Downff  $
(ff$ %
MigrationBuilderff% 5
migrationBuilderff6 F
)ffF G
{gg 	
migrationBuilderhh 
.hh 
DropForeignKeyhh +
(hh+ ,
nameii 
:ii 
$strii ?
,ii? @
tablejj 
:jj 
$strjj '
)jj' (
;jj( )
migrationBuilderll 
.ll 
DropForeignKeyll +
(ll+ ,
namemm 
:mm 
$strmm 8
,mm8 9
tablenn 
:nn 
$strnn '
)nn' (
;nn( )
migrationBuilderpp 
.pp 
	DropIndexpp &
(pp& '
nameqq 
:qq 
$strqq 4
,qq4 5
tablerr 
:rr 
$strrr '
)rr' (
;rr( )
migrationBuildertt 
.tt 
	DropIndextt &
(tt& '
nameuu 
:uu 
$struu 1
,uu1 2
tablevv 
:vv 
$strvv '
)vv' (
;vv( )
migrationBuilderxx 
.xx 
RenameColumnxx )
(xx) *
nameyy 
:yy 
$stryy %
,yy% &
tablezz 
:zz 
$strzz  
,zz  !
newName{{ 
:{{ 
$str{{ "
){{" #
;{{# $
migrationBuilder}} 
.}} 
	AddColumn}} &
<}}& '
Guid}}' +
>}}+ ,
(}}, -
name~~ 
:~~ 
$str~~ "
,~~" #
table 
: 
$str  
,  !
type
�� 
:
�� 
$str
�� (
,
��( )
nullable
�� 
:
�� 
true
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	AddColumn
�� &
<
��& '
string
��' -
>
��- .
(
��. /
name
�� 
:
�� 
$str
�� $
,
��$ %
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
true
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	AddColumn
�� &
<
��& '
string
��' -
>
��- .
(
��. /
name
�� 
:
�� 
$str
�� #
,
��# $
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
true
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	AddColumn
�� &
<
��& '
int
��' *
>
��* +
(
��+ ,
name
�� 
:
�� 
$str
�� $
,
��$ %
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� 
,
�� 
nullable
�� 
:
�� 
true
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	AddColumn
�� &
<
��& '
double
��' -
>
��- .
(
��. /
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� 
,
�� 
nullable
�� 
:
�� 
true
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	AddColumn
�� &
<
��& '
double
��' -
>
��- .
(
��. /
name
�� 
:
�� 
$str
�� 
,
�� 
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� 
,
�� 
nullable
�� 
:
�� 
true
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	AddColumn
�� &
<
��& '
string
��' -
>
��- .
(
��. /
name
�� 
:
�� 
$str
�� 
,
�� 
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
true
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� &
,
��& '
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
CourseId
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
Guid
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 J
,
��J K
nullable
��L T
:
��T U
false
��V [
)
��[ \
,
��\ ]
Description
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
string
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= L
,
��L M
nullable
��N V
:
��V W
false
��X ]
)
��] ^
,
��^ _
Title
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
string
��) /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 8
,
��8 9
x
��: ;
=>
��< >
x
��? @
.
��@ A
Id
��A C
)
��C D
;
��D E
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
CourseId
��' /
,
��/ 0
principalTable
�� &
:
��& '
$str
��( 1
,
��1 2
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� &
,
��& '
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
CourseSectionId
�� #
=
��$ %
table
��& +
.
��+ ,
Column
��, 2
<
��2 3
Guid
��3 7
>
��7 8
(
��8 9
type
��9 =
:
��= >
$str
��? Q
,
��Q R
nullable
��S [
:
��[ \
false
��] b
)
��b c
,
��c d
DocsUrl
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
string
��+ 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 H
,
��H I
nullable
��J R
:
��R S
true
��T X
)
��X Y
,
��Y Z
Name
�� 
=
�� 
table
��  
.
��  !
Column
��! '
<
��' (
string
��( .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 E
,
��E F
nullable
��G O
:
��O P
false
��Q V
)
��V W
,
��W X
SlideUrl
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
string
��, 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
,
��[ \
Type
�� 
=
�� 
table
��  
.
��  !
Column
��! '
<
��' (
int
��( +
>
��+ ,
(
��, -
type
��- 1
:
��1 2
$str
��3 8
,
��8 9
nullable
��: B
:
��B C
true
��D H
)
��H I
,
��I J
VideoUrl
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
string
��, 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 8
,
��8 9
x
��: ;
=>
��< >
x
��? @
.
��@ A
Id
��A C
)
��C D
;
��D E
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� P
,
��P Q
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
CourseSectionId
��' 6
,
��6 7
principalTable
�� &
:
��& '
$str
��( 8
,
��8 9
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� $
,
��$ %
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
$str
�� +
,
��+ ,
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! 3
,
��3 4
$str
��5 A
,
��A B
$str
��C Q
,
��Q R
$str
��S b
}
��c d
,
��d e
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
]
��# $
{
��% &
$str
��' M
,
��M N
new
��O R
DateTime
��S [
(
��[ \
$num
��\ `
,
��` a
$num
��b c
,
��c d
$num
��e f
,
��f g
$num
��h i
,
��i j
$num
��k m
,
��m n
$num
��o q
,
��q r
$num
��s v
,
��v w
DateTimeKind��x �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
)��� �
;��� �
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� -
,
��- .
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� *
,
��* +
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� '
,
��' (
column
�� 
:
�� 
$str
�� "
)
��" #
;
��# $
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 9
,
��9 :
table
�� 
:
�� 
$str
�� '
,
��' (
column
�� 
:
�� 
$str
�� )
)
��) *
;
��* +
migrationBuilder
�� 
.
�� 
AddForeignKey
�� *
(
��* +
name
�� 
:
�� 
$str
�� 8
,
��8 9
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� $
,
��$ %
principalTable
�� 
:
�� 
$str
��  ,
,
��, -
principalColumn
�� 
:
��  
$str
��! %
)
��% &
;
��& '
migrationBuilder
�� 
.
�� 
AddForeignKey
�� *
(
��* +
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� !
,
��! "
principalTable
�� 
:
�� 
$str
��  (
,
��( )
principalColumn
�� 
:
��  
$str
��! %
)
��% &
;
��& '
}
�� 	
}
�� 
}�� �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240701051059_AddMoreUrlToSectionDetails.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 &
AddMoreUrlToSectionDetails		 3
:		4 5
	Migration		6 ?
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
RenameColumn )
() *
name 
: 
$str  
,  !
table 
: 
$str /
,/ 0
newName 
: 
$str #
)# $
;$ %
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str 
,  
table 
: 
$str '
,' (
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str  
,  !
table 
: 
$str '
,' (
type 
: 
$str %
,% &
nullable 
: 
false 
,  
defaultValue 
: 
$str  
)  !
;! "
migrationBuilder   
.   
	AddColumn   &
<  & '
int  ' *
>  * +
(  + ,
name!! 
:!! 
$str!! 
,!! 
table"" 
:"" 
$str"" '
,""' (
type## 
:## 
$str## 
,## 
nullable$$ 
:$$ 
true$$ 
)$$ 
;$$  
}%% 	
	protected(( 
override(( 
void(( 
Down((  $
((($ %
MigrationBuilder((% 5
migrationBuilder((6 F
)((F G
{)) 	
migrationBuilder** 
.** 

DropColumn** '
(**' (
name++ 
:++ 
$str++ 
,++  
table,, 
:,, 
$str,, '
),,' (
;,,( )
migrationBuilder.. 
... 

DropColumn.. '
(..' (
name// 
:// 
$str//  
,//  !
table00 
:00 
$str00 '
)00' (
;00( )
migrationBuilder22 
.22 

DropColumn22 '
(22' (
name33 
:33 
$str33 
,33 
table44 
:44 
$str44 '
)44' (
;44( )
migrationBuilder66 
.66 
RenameColumn66 )
(66) *
name77 
:77 
$str77  
,77  !
table88 
:88 
$str88 /
,88/ 0
newName99 
:99 
$str99 #
)99# $
;99$ %
};; 	
}<< 
}== �9
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240629022632_AddMoreColumnForCourseTable.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 '
AddMoreColumnForCourseTable		 4
:		5 6
	Migration		7 @
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str #
,# $
table 
: 
$str '
,' (
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str 
,  
table 
: 
$str '
,' (
type 
: 
$str 
, 
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str !
,! "
table 
: 
$str  
,  !
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
migrationBuilder   
.   
	AddColumn   &
<  & '
DateTime  ' /
>  / 0
(  0 1
name!! 
:!! 
$str!! #
,!!# $
table"" 
:"" 
$str""  
,""  !
type## 
:## 
$str## !
,##! "
nullable$$ 
:$$ 
true$$ 
)$$ 
;$$  
migrationBuilder&& 
.&& 
	AddColumn&& &
<&&& '
string&&' -
>&&- .
(&&. /
name'' 
:'' 
$str''  
,''  !
table(( 
:(( 
$str((  
,((  !
type)) 
:)) 
$str)) %
,))% &
nullable** 
:** 
true** 
)** 
;**  
migrationBuilder,, 
.,, 
	AddColumn,, &
<,,& '
DateTime,,' /
>,,/ 0
(,,0 1
name-- 
:-- 
$str-- "
,--" #
table.. 
:.. 
$str..  
,..  !
type// 
:// 
$str// !
,//! "
nullable00 
:00 
true00 
)00 
;00  
migrationBuilder22 
.22 

UpdateData22 '
(22' (
table33 
:33 
$str33 $
,33$ %
	keyColumn44 
:44 
$str44 
,44  
keyValue55 
:55 
$str55 +
,55+ ,
columns66 
:66 
new66 
[66 
]66 
{66  
$str66! 3
,663 4
$str665 A
,66A B
$str66C Q
,66Q R
$str66S b
}66c d
,66d e
values77 
:77 
new77 
object77 "
[77" #
]77# $
{77% &
$str77' M
,77M N
new77O R
DateTime77S [
(77[ \
$num77\ `
,77` a
$num77b c
,77c d
$num77e g
,77g h
$num77i j
,77j k
$num77l n
,77n o
$num77p r
,77r s
$num77t w
,77w x
DateTimeKind	77y �
.
77� �
Utc
77� �
)
77� �
.
77� �
AddTicks
77� �
(
77� �
$num
77� �
)
77� �
,
77� �
$str
77� �
,
77� �
$str
77� �
}
77� �
)
77� �
;
77� �
}88 	
	protected;; 
override;; 
void;; 
Down;;  $
(;;$ %
MigrationBuilder;;% 5
migrationBuilder;;6 F
);;F G
{<< 	
migrationBuilder== 
.== 

DropColumn== '
(==' (
name>> 
:>> 
$str>> #
,>># $
table?? 
:?? 
$str?? '
)??' (
;??( )
migrationBuilderAA 
.AA 

DropColumnAA '
(AA' (
nameBB 
:BB 
$strBB 
,BB  
tableCC 
:CC 
$strCC '
)CC' (
;CC( )
migrationBuilderEE 
.EE 

DropColumnEE '
(EE' (
nameFF 
:FF 
$strFF !
,FF! "
tableGG 
:GG 
$strGG  
)GG  !
;GG! "
migrationBuilderII 
.II 

DropColumnII '
(II' (
nameJJ 
:JJ 
$strJJ #
,JJ# $
tableKK 
:KK 
$strKK  
)KK  !
;KK! "
migrationBuilderMM 
.MM 

DropColumnMM '
(MM' (
nameNN 
:NN 
$strNN  
,NN  !
tableOO 
:OO 
$strOO  
)OO  !
;OO! "
migrationBuilderQQ 
.QQ 

DropColumnQQ '
(QQ' (
nameRR 
:RR 
$strRR "
,RR" #
tableSS 
:SS 
$strSS  
)SS  !
;SS! "
migrationBuilderUU 
.UU 

UpdateDataUU '
(UU' (
tableVV 
:VV 
$strVV $
,VV$ %
	keyColumnWW 
:WW 
$strWW 
,WW  
keyValueXX 
:XX 
$strXX +
,XX+ ,
columnsYY 
:YY 
newYY 
[YY 
]YY 
{YY  
$strYY! 3
,YY3 4
$strYY5 A
,YYA B
$strYYC Q
,YYQ R
$strYYS b
}YYc d
,YYd e
valuesZZ 
:ZZ 
newZZ 
objectZZ "
[ZZ" #
]ZZ# $
{ZZ% &
$strZZ' M
,ZZM N
newZZO R
DateTimeZZS [
(ZZ[ \
$numZZ\ `
,ZZ` a
$numZZb c
,ZZc d
$numZZe g
,ZZg h
$numZZi k
,ZZk l
$numZZm o
,ZZo p
$numZZq s
,ZZs t
$numZZu x
,ZZx y
DateTimeKind	ZZz �
.
ZZ� �
Utc
ZZ� �
)
ZZ� �
.
ZZ� �
AddTicks
ZZ� �
(
ZZ� �
$num
ZZ� �
)
ZZ� �
,
ZZ� �
$str
ZZ� �
,
ZZ� �
$str
ZZ� �
}
ZZ� �
)
ZZ� �
;
ZZ� �
}[[ 	
}\\ 
}]] �&
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628165735_AllowNullForCourseVerionInstructor.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 .
"AllowNullForCourseVerionInstructor		 ;
:		< =
	Migration		> G
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
AlterColumn (
<( )
Guid) -
>- .
(. /
name 
: 
$str $
,$ %
table 
: 
$str '
,' (
type 
: 
$str (
,( )
nullable 
: 
true 
, 

oldClrType 
: 
typeof "
(" #
Guid# '
)' (
,( )
oldType 
: 
$str +
)+ ,
;, -
migrationBuilder 
. 

UpdateData '
(' (
table 
: 
$str $
,$ %
	keyColumn 
: 
$str 
,  
keyValue 
: 
$str +
,+ ,
columns 
: 
new 
[ 
] 
{  
$str! 3
,3 4
$str5 A
,A B
$strC Q
,Q R
$strS b
}c d
,d e
values 
: 
new 
object "
[" #
]# $
{% &
$str' M
,M N
newO R
DateTimeS [
([ \
$num\ `
,` a
$numb c
,c d
$nume g
,g h
$numi k
,k l
$numm o
,o p
$numq s
,s t
$numu x
,x y
DateTimeKind	z �
.
� �
Utc
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
,
� �
$str
� �
,
� �
$str
� �
}
� �
)
� �
;
� �
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{   	
migrationBuilder!! 
.!! 
AlterColumn!! (
<!!( )
Guid!!) -
>!!- .
(!!. /
name"" 
:"" 
$str"" $
,""$ %
table## 
:## 
$str## '
,##' (
type$$ 
:$$ 
$str$$ (
,$$( )
nullable%% 
:%% 
false%% 
,%%  
defaultValue&& 
:&& 
new&& !
Guid&&" &
(&&& '
$str&&' M
)&&M N
,&&N O

oldClrType'' 
:'' 
typeof'' "
(''" #
Guid''# '
)''' (
,''( )
oldType(( 
:(( 
$str(( +
,((+ ,
oldNullable)) 
:)) 
true)) !
)))! "
;))" #
migrationBuilder++ 
.++ 

UpdateData++ '
(++' (
table,, 
:,, 
$str,, $
,,,$ %
	keyColumn-- 
:-- 
$str-- 
,--  
keyValue.. 
:.. 
$str.. +
,..+ ,
columns// 
:// 
new// 
[// 
]// 
{//  
$str//! 3
,//3 4
$str//5 A
,//A B
$str//C Q
,//Q R
$str//S b
}//c d
,//d e
values00 
:00 
new00 
object00 "
[00" #
]00# $
{00% &
$str00' M
,00M N
new00O R
DateTime00S [
(00[ \
$num00\ `
,00` a
$num00b c
,00c d
$num00e g
,00g h
$num00i k
,00k l
$num00m o
,00o p
$num00q s
,00s t
$num00u x
,00x y
DateTimeKind	00z �
.
00� �
Utc
00� �
)
00� �
.
00� �
AddTicks
00� �
(
00� �
$num
00� �
)
00� �
,
00� �
$str
00� �
,
00� �
$str
00� �
}
00� �
)
00� �
;
00� �
}11 	
}22 
}33 ��
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628164825_AllowNullForCourseProps.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 #
AllowNullForCourseProps		 0
:		1 2
	Migration		3 <
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str 8
,8 9
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str ;
,; <
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str 1
,1 2
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 
AlterColumn (
<( )
int) ,
>, -
(- .
name 
: 
$str 
,  
table 
: 
$str  
,  !
type 
: 
$str 
, 
nullable 
: 
true 
, 

oldClrType 
: 
typeof "
(" #
int# &
)& '
,' (
oldType   
:   
$str   
)   
;    
migrationBuilder"" 
."" 
AlterColumn"" (
<""( )
float"") .
>"". /
(""/ 0
name## 
:## 
$str## !
,##! "
table$$ 
:$$ 
$str$$  
,$$  !
type%% 
:%% 
$str%% 
,%% 
nullable&& 
:&& 
true&& 
,&& 

oldClrType'' 
:'' 
typeof'' "
(''" #
float''# (
)''( )
,'') *
oldType(( 
:(( 
$str(( 
)((  
;((  !
migrationBuilder** 
.** 
AlterColumn** (
<**( )
string**) /
>**/ 0
(**0 1
name++ 
:++ 
$str++ 
,++ 
table,, 
:,, 
$str,,  
,,,  !
type-- 
:-- 
$str-- %
,--% &
nullable.. 
:.. 
true.. 
,.. 

oldClrType// 
:// 
typeof// "
(//" #
string//# )
)//) *
,//* +
oldType00 
:00 
$str00 (
)00( )
;00) *
migrationBuilder22 
.22 
AlterColumn22 (
<22( )
int22) ,
>22, -
(22- .
name33 
:33 
$str33 #
,33# $
table44 
:44 
$str44  
,44  !
type55 
:55 
$str55 
,55 
nullable66 
:66 
true66 
,66 

oldClrType77 
:77 
typeof77 "
(77" #
int77# &
)77& '
,77' (
oldType88 
:88 
$str88 
)88 
;88  
migrationBuilder:: 
.:: 
AlterColumn:: (
<::( )
double::) /
>::/ 0
(::0 1
name;; 
:;; 
$str;; 
,;; 
table<< 
:<< 
$str<<  
,<<  !
type== 
:== 
$str== 
,== 
nullable>> 
:>> 
true>> 
,>> 

oldClrType?? 
:?? 
typeof?? "
(??" #
double??# )
)??) *
,??* +
oldType@@ 
:@@ 
$str@@  
)@@  !
;@@! "
migrationBuilderBB 
.BB 
AlterColumnBB (
<BB( )
GuidBB) -
>BB- .
(BB. /
nameCC 
:CC 
$strCC 
,CC  
tableDD 
:DD 
$strDD  
,DD  !
typeEE 
:EE 
$strEE (
,EE( )
nullableFF 
:FF 
trueFF 
,FF 

oldClrTypeGG 
:GG 
typeofGG "
(GG" #
GuidGG# '
)GG' (
,GG( )
oldTypeHH 
:HH 
$strHH +
)HH+ ,
;HH, -
migrationBuilderJJ 
.JJ 
AlterColumnJJ (
<JJ( )
intJJ) ,
>JJ, -
(JJ- .
nameKK 
:KK 
$strKK $
,KK$ %
tableLL 
:LL 
$strLL  
,LL  !
typeMM 
:MM 
$strMM 
,MM 
nullableNN 
:NN 
trueNN 
,NN 

oldClrTypeOO 
:OO 
typeofOO "
(OO" #
intOO# &
)OO& '
,OO' (
oldTypePP 
:PP 
$strPP 
)PP 
;PP  
migrationBuilderRR 
.RR 
AlterColumnRR (
<RR( )
GuidRR) -
>RR- .
(RR. /
nameSS 
:SS 
$strSS $
,SS$ %
tableTT 
:TT 
$strTT  
,TT  !
typeUU 
:UU 
$strUU (
,UU( )
nullableVV 
:VV 
trueVV 
,VV 

oldClrTypeWW 
:WW 
typeofWW "
(WW" #
GuidWW# '
)WW' (
,WW( )
oldTypeXX 
:XX 
$strXX +
)XX+ ,
;XX, -
migrationBuilderZZ 
.ZZ 
AlterColumnZZ (
<ZZ( )
stringZZ) /
>ZZ/ 0
(ZZ0 1
name[[ 
:[[ 
$str[[ #
,[[# $
table\\ 
:\\ 
$str\\  
,\\  !
type]] 
:]] 
$str]] %
,]]% &
nullable^^ 
:^^ 
true^^ 
,^^ 

oldClrType__ 
:__ 
typeof__ "
(__" #
string__# )
)__) *
,__* +
oldType`` 
:`` 
$str`` (
)``( )
;``) *
migrationBuilderbb 
.bb 
AlterColumnbb (
<bb( )
stringbb) /
>bb/ 0
(bb0 1
namecc 
:cc 
$strcc 
,cc 
tabledd 
:dd 
$strdd  
,dd  !
typeee 
:ee 
$stree %
,ee% &
nullableff 
:ff 
trueff 
,ff 

oldClrTypegg 
:gg 
typeofgg "
(gg" #
stringgg# )
)gg) *
,gg* +
oldTypehh 
:hh 
$strhh (
)hh( )
;hh) *
migrationBuilderjj 
.jj 
AlterColumnjj (
<jj( )
Guidjj) -
>jj- .
(jj. /
namekk 
:kk 
$strkk "
,kk" #
tablell 
:ll 
$strll  
,ll  !
typemm 
:mm 
$strmm (
,mm( )
nullablenn 
:nn 
truenn 
,nn 

oldClrTypeoo 
:oo 
typeofoo "
(oo" #
Guidoo# '
)oo' (
,oo( )
oldTypepp 
:pp 
$strpp +
)pp+ ,
;pp, -
migrationBuilderrr 
.rr 
AddForeignKeyrr *
(rr* +
namess 
:ss 
$strss 8
,ss8 9
tablett 
:tt 
$strtt  
,tt  !
columnuu 
:uu 
$struu $
,uu$ %
principalTablevv 
:vv 
$strvv  ,
,vv, -
principalColumnww 
:ww  
$strww! %
)ww% &
;ww& '
migrationBuilderyy 
.yy 
AddForeignKeyyy *
(yy* +
namezz 
:zz 
$strzz ;
,zz; <
table{{ 
:{{ 
$str{{  
,{{  !
column|| 
:|| 
$str|| &
,||& '
principalTable}} 
:}} 
$str}}  -
,}}- .
principalColumn~~ 
:~~  
$str~~! /
)~~/ 0
;~~0 1
migrationBuilder
�� 
.
�� 
AddForeignKey
�� *
(
��* +
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� !
,
��! "
principalTable
�� 
:
�� 
$str
��  (
,
��( )
principalColumn
�� 
:
��  
$str
��! %
)
��% &
;
��& '
}
�� 	
	protected
�� 
override
�� 
void
�� 
Down
��  $
(
��$ %
MigrationBuilder
��% 5
migrationBuilder
��6 F
)
��F G
{
�� 	
migrationBuilder
�� 
.
�� 
DropForeignKey
�� +
(
��+ ,
name
�� 
:
�� 
$str
�� 8
,
��8 9
table
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
DropForeignKey
�� +
(
��+ ,
name
�� 
:
�� 
$str
�� ;
,
��; <
table
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
DropForeignKey
�� +
(
��+ ,
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
int
��) ,
>
��, -
(
��- .
name
�� 
:
�� 
$str
�� 
,
��  
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� 
,
�� 
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$num
�� 
,
��  

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
int
��# &
)
��& '
,
��' (
oldType
�� 
:
�� 
$str
�� 
,
�� 
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
float
��) .
>
��. /
(
��/ 0
name
�� 
:
�� 
$str
�� !
,
��! "
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� 
,
�� 
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$num
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
float
��# (
)
��( )
,
��) *
oldType
�� 
:
�� 
$str
�� 
,
��  
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
�� 
,
�� 
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
int
��) ,
>
��, -
(
��- .
name
�� 
:
�� 
$str
�� #
,
��# $
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� 
,
�� 
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$num
�� 
,
��  

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
int
��# &
)
��& '
,
��' (
oldType
�� 
:
�� 
$str
�� 
,
�� 
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
double
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
�� 
,
�� 
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� 
,
�� 
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$num
�� !
,
��! "

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
double
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
��  
,
��  !
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
Guid
��) -
>
��- .
(
��. /
name
�� 
:
�� 
$str
�� 
,
��  
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� (
,
��( )
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
Guid
��" &
(
��& '
$str
��' M
)
��M N
,
��N O

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
Guid
��# '
)
��' (
,
��( )
oldType
�� 
:
�� 
$str
�� +
,
��+ ,
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
int
��) ,
>
��, -
(
��- .
name
�� 
:
�� 
$str
�� $
,
��$ %
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� 
,
�� 
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$num
�� 
,
��  

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
int
��# &
)
��& '
,
��' (
oldType
�� 
:
�� 
$str
�� 
,
�� 
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
Guid
��) -
>
��- .
(
��. /
name
�� 
:
�� 
$str
�� $
,
��$ %
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� (
,
��( )
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
Guid
��" &
(
��& '
$str
��' M
)
��M N
,
��N O

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
Guid
��# '
)
��' (
,
��( )
oldType
�� 
:
�� 
$str
�� +
,
��+ ,
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
�� #
,
��# $
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
�� 
,
�� 
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
Guid
��) -
>
��- .
(
��. /
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
��  
,
��  !
type
�� 
:
�� 
$str
�� (
,
��( )
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
Guid
��" &
(
��& '
$str
��' M
)
��M N
,
��N O

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
Guid
��# '
)
��' (
,
��( )
oldType
�� 
:
�� 
$str
�� +
,
��+ ,
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AddForeignKey
�� *
(
��* +
name
�� 
:
�� 
$str
�� 8
,
��8 9
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� $
,
��$ %
principalTable
�� 
:
�� 
$str
��  ,
,
��, -
principalColumn
�� 
:
��  
$str
��! %
,
��% &
onDelete
�� 
:
�� 
ReferentialAction
�� +
.
��+ ,
Cascade
��, 3
)
��3 4
;
��4 5
migrationBuilder
�� 
.
�� 
AddForeignKey
�� *
(
��* +
name
�� 
:
�� 
$str
�� ;
,
��; <
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� &
,
��& '
principalTable
�� 
:
�� 
$str
��  -
,
��- .
principalColumn
�� 
:
��  
$str
��! /
,
��/ 0
onDelete
�� 
:
�� 
ReferentialAction
�� +
.
��+ ,
Cascade
��, 3
)
��3 4
;
��4 5
migrationBuilder
�� 
.
�� 
AddForeignKey
�� *
(
��* +
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� !
,
��! "
principalTable
�� 
:
�� 
$str
��  (
,
��( )
principalColumn
�� 
:
��  
$str
��! %
,
��% &
onDelete
�� 
:
�� 
ReferentialAction
�� +
.
��+ ,
Cascade
��, 3
)
��3 4
;
��4 5
}
�� 	
}
�� 
}�� �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628164354_RenameColumnInCourseVersion.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 '
RenameColumnInCourseVersion		 4
:		5 6
	Migration		7 @
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str A
,A B
table 
: 
$str '
)' (
;( )
migrationBuilder 
. 
RenameColumn )
() *
name 
: 
$str '
,' (
table 
: 
$str '
,' (
newName 
: 
$str #
)# $
;$ %
migrationBuilder 
. 
RenameIndex (
(( )
name 
: 
$str 9
,9 :
table 
: 
$str '
,' (
newName 
: 
$str 5
)5 6
;6 7
migrationBuilder 
. 
AddForeignKey *
(* +
name 
: 
$str :
,: ;
table 
: 
$str '
,' (
column 
: 
$str "
," #
principalTable   
:   
$str    )
,  ) *
principalColumn!! 
:!!  
$str!!! %
)!!% &
;!!& '
}"" 	
	protected%% 
override%% 
void%% 
Down%%  $
(%%$ %
MigrationBuilder%%% 5
migrationBuilder%%6 F
)%%F G
{&& 	
migrationBuilder'' 
.'' 
DropForeignKey'' +
(''+ ,
name(( 
:(( 
$str(( :
,((: ;
table)) 
:)) 
$str)) '
)))' (
;))( )
migrationBuilder++ 
.++ 
RenameColumn++ )
(++) *
name,, 
:,, 
$str,,  
,,,  !
table-- 
:-- 
$str-- '
,--' (
newName.. 
:.. 
$str.. *
)..* +
;..+ ,
migrationBuilder00 
.00 
RenameIndex00 (
(00( )
name11 
:11 
$str11 2
,112 3
table22 
:22 
$str22 '
,22' (
newName33 
:33 
$str33 <
)33< =
;33= >
migrationBuilder55 
.55 
AddForeignKey55 *
(55* +
name66 
:66 
$str66 A
,66A B
table77 
:77 
$str77 '
,77' (
column88 
:88 
$str88 )
,88) *
principalTable99 
:99 
$str99  )
,99) *
principalColumn:: 
:::  
$str::! %
)::% &
;::& '
};; 	
}<< 
}== �Q
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628080934_RemoveStatusTableAndSomeForeignkey.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 .
"RemoveStatusTableAndSomeForeignkey		 ;
:		< =
	Migration		> G
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str O
,O P
table 
: 
$str .
). /
;/ 0
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str Q
,Q R
table 
: 
$str /
)/ 0
;0 1
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str 2
)2 3
;3 4
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str 3
)3 4
;4 5
migrationBuilder 
. 
	DropIndex &
(& '
name 
: 
$str B
,B C
table 
: 
$str /
)/ 0
;0 1
migrationBuilder   
.   
	DropIndex   &
(  & '
name!! 
:!! 
$str!! @
,!!@ A
table"" 
:"" 
$str"" .
)"". /
;""/ 0
migrationBuilder$$ 
.$$ 

DropColumn$$ '
($$' (
name%% 
:%% 
$str%% (
,%%( )
table&& 
:&& 
$str&& /
)&&/ 0
;&&0 1
migrationBuilder(( 
.(( 

DropColumn(( '
(((' (
name)) 
:)) 
$str)) '
,))' (
table** 
:** 
$str** .
)**. /
;**/ 0
}++ 	
	protected.. 
override.. 
void.. 
Down..  $
(..$ %
MigrationBuilder..% 5
migrationBuilder..6 F
)..F G
{// 	
migrationBuilder00 
.00 
	AddColumn00 &
<00& '
Guid00' +
>00+ ,
(00, -
name11 
:11 
$str11 (
,11( )
table22 
:22 
$str22 /
,22/ 0
type33 
:33 
$str33 (
,33( )
nullable44 
:44 
false44 
,44  
defaultValue55 
:55 
new55 !
Guid55" &
(55& '
$str55' M
)55M N
)55N O
;55O P
migrationBuilder77 
.77 
	AddColumn77 &
<77& '
Guid77' +
>77+ ,
(77, -
name88 
:88 
$str88 '
,88' (
table99 
:99 
$str99 .
,99. /
type:: 
::: 
$str:: (
,::( )
nullable;; 
:;; 
true;; 
);; 
;;;  
migrationBuilder== 
.== 
CreateTable== (
(==( )
name>> 
:>> 
$str>> 2
,>>2 3
columns?? 
:?? 
table?? 
=>?? !
new??" %
{@@ 
IdAA 
=AA 
tableAA 
.AA 
ColumnAA %
<AA% &
GuidAA& *
>AA* +
(AA+ ,
typeAA, 0
:AA0 1
$strAA2 D
,AAD E
nullableAAF N
:AAN O
falseAAP U
)AAU V
,AAV W"
CourseSectionVersionIdBB *
=BB+ ,
tableBB- 2
.BB2 3
ColumnBB3 9
<BB9 :
GuidBB: >
>BB> ?
(BB? @
typeBB@ D
:BBD E
$strBBF X
,BBX Y
nullableBBZ b
:BBb c
trueBBd h
)BBh i
,BBi j

CreateTimeCC 
=CC  
tableCC! &
.CC& '
ColumnCC' -
<CC- .
DateTimeCC. 6
>CC6 7
(CC7 8
typeCC8 <
:CC< =
$strCC> I
,CCI J
nullableCCK S
:CCS T
falseCCU Z
)CCZ [
,CC[ \
StatusDD 
=DD 
tableDD "
.DD" #
ColumnDD# )
<DD) *
intDD* -
>DD- .
(DD. /
typeDD/ 3
:DD3 4
$strDD5 :
,DD: ;
nullableDD< D
:DDD E
falseDDF K
)DDK L
}EE 
,EE 
constraintsFF 
:FF 
tableFF "
=>FF# %
{GG 
tableHH 
.HH 

PrimaryKeyHH $
(HH$ %
$strHH% D
,HHD E
xHHF G
=>HHH J
xHHK L
.HHL M
IdHHM O
)HHO P
;HHP Q
tableII 
.II 

ForeignKeyII $
(II$ %
nameJJ 
:JJ 
$strJJ j
,JJj k
columnKK 
:KK 
xKK  !
=>KK" $
xKK% &
.KK& '"
CourseSectionVersionIdKK' =
,KK= >
principalTableLL &
:LL& '
$strLL( ?
,LL? @
principalColumnMM '
:MM' (
$strMM) -
)MM- .
;MM. /
}NN 
)NN 
;NN 
migrationBuilderPP 
.PP 
CreateTablePP (
(PP( )
nameQQ 
:QQ 
$strQQ 3
,QQ3 4
columnsRR 
:RR 
tableRR 
=>RR !
newRR" %
{SS 
IdTT 
=TT 
tableTT 
.TT 
ColumnTT %
<TT% &
GuidTT& *
>TT* +
(TT+ ,
typeTT, 0
:TT0 1
$strTT2 D
,TTD E
nullableTTF N
:TTN O
falseTTP U
)TTU V
,TTV W#
SectionDetailsVersionIdUU +
=UU, -
tableUU. 3
.UU3 4
ColumnUU4 :
<UU: ;
GuidUU; ?
>UU? @
(UU@ A
typeUUA E
:UUE F
$strUUG Y
,UUY Z
nullableUU[ c
:UUc d
trueUUe i
)UUi j
,UUj k

CreateTimeVV 
=VV  
tableVV! &
.VV& '
ColumnVV' -
<VV- .
DateTimeVV. 6
>VV6 7
(VV7 8
typeVV8 <
:VV< =
$strVV> I
,VVI J
nullableVVK S
:VVS T
falseVVU Z
)VVZ [
,VV[ \
StatusWW 
=WW 
tableWW "
.WW" #
ColumnWW# )
<WW) *
intWW* -
>WW- .
(WW. /
typeWW/ 3
:WW3 4
$strWW5 :
,WW: ;
nullableWW< D
:WWD E
falseWWF K
)WWK L
}XX 
,XX 
constraintsYY 
:YY 
tableYY "
=>YY# %
{ZZ 
table[[ 
.[[ 

PrimaryKey[[ $
([[$ %
$str[[% E
,[[E F
x[[G H
=>[[I K
x[[L M
.[[M N
Id[[N P
)[[P Q
;[[Q R
table\\ 
.\\ 

ForeignKey\\ $
(\\$ %
name]] 
:]] 
$str]] m
,]]m n
column^^ 
:^^ 
x^^  !
=>^^" $
x^^% &
.^^& '#
SectionDetailsVersionId^^' >
,^^> ?
principalTable__ &
:__& '
$str__( @
,__@ A
principalColumn`` '
:``' (
$str``) -
)``- .
;``. /
}aa 
)aa 
;aa 
migrationBuildercc 
.cc 
CreateIndexcc (
(cc( )
namedd 
:dd 
$strdd B
,ddB C
tableee 
:ee 
$stree /
,ee/ 0
columnff 
:ff 
$strff *
)ff* +
;ff+ ,
migrationBuilderhh 
.hh 
CreateIndexhh (
(hh( )
nameii 
:ii 
$strii @
,ii@ A
tablejj 
:jj 
$strjj .
,jj. /
columnkk 
:kk 
$strkk )
)kk) *
;kk* +
migrationBuildermm 
.mm 
CreateIndexmm (
(mm( )
namenn 
:nn 
$strnn L
,nnL M
tableoo 
:oo 
$stroo 3
,oo3 4
columnpp 
:pp 
$strpp 0
)pp0 1
;pp1 2
migrationBuilderrr 
.rr 
CreateIndexrr (
(rr( )
namess 
:ss 
$strss N
,ssN O
tablett 
:tt 
$strtt 4
,tt4 5
columnuu 
:uu 
$struu 1
)uu1 2
;uu2 3
migrationBuilderww 
.ww 
AddForeignKeyww *
(ww* +
namexx 
:xx 
$strxx O
,xxO P
tableyy 
:yy 
$stryy .
,yy. /
columnzz 
:zz 
$strzz )
,zz) *
principalTable{{ 
:{{ 
$str{{  0
,{{0 1
principalColumn|| 
:||  
$str||! %
)||% &
;||& '
migrationBuilder~~ 
.~~ 
AddForeignKey~~ *
(~~* +
name 
: 
$str Q
,Q R
table
�� 
:
�� 
$str
�� /
,
��/ 0
column
�� 
:
�� 
$str
�� *
,
��* +
principalTable
�� 
:
�� 
$str
��  0
,
��0 1
principalColumn
�� 
:
��  
$str
��! %
,
��% &
onDelete
�� 
:
�� 
ReferentialAction
�� +
.
��+ ,
Cascade
��, 3
)
��3 4
;
��4 5
}
�� 	
}
�� 
}�� �&
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628062641_AddCourseCommentTable.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 !
AddCourseCommentTable		 .
:		/ 0
	Migration		1 :
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str -
,- .
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 D
,D E
nullableF N
:N O
falseP U
)U V
,V W
CourseVersionId #
=$ %
table& +
.+ ,
Column, 2
<2 3
Guid3 7
>7 8
(8 9
type9 =
:= >
$str? Q
,Q R
nullableS [
:[ \
false] b
)b c
,c d
Comment 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
CreateBy 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
trueU Y
)Y Z
,Z [

CreateTime 
=  
table! &
.& '
Column' -
<- .
DateTime. 6
>6 7
(7 8
type8 <
:< =
$str> I
,I J
nullableK S
:S T
trueU Y
)Y Z
,Z [
UpdateBy 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
trueU Y
)Y Z
,Z [

UpdateTime 
=  
table! &
.& '
Column' -
<- .
DateTime. 6
>6 7
(7 8
type8 <
:< =
$str> I
,I J
nullableK S
:S T
trueU Y
)Y Z
,Z [
Status 
= 
table "
." #
Column# )
<) *
int* -
>- .
(. /
type/ 3
:3 4
$str5 :
,: ;
nullable< D
:D E
falseF K
)K L
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% ?
,? @
xA B
=>C E
xF G
.G H
IdH J
)J K
;K L
table 
. 

ForeignKey $
($ %
name 
: 
$str W
,W X
column   
:   
x    !
=>  " $
x  % &
.  & '
CourseVersionId  ' 6
,  6 7
principalTable!! &
:!!& '
$str!!( 8
,!!8 9
principalColumn"" '
:""' (
$str"") -
,""- .
onDelete##  
:##  !
ReferentialAction##" 3
.##3 4
Cascade##4 ;
)##; <
;##< =
}$$ 
)$$ 
;$$ 
migrationBuilder&& 
.&& 
CreateIndex&& (
(&&( )
name'' 
:'' 
$str'' @
,''@ A
table(( 
:(( 
$str(( .
,((. /
column)) 
:)) 
$str)) )
)))) *
;))* +
}** 	
	protected-- 
override-- 
void-- 
Down--  $
(--$ %
MigrationBuilder--% 5
migrationBuilder--6 F
)--F G
{.. 	
migrationBuilder// 
.// 
	DropTable// &
(//& '
name00 
:00 
$str00 -
)00- .
;00. /
}22 	
}33 
}44 �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628061226_AddVersionIntCourseTable.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 $
AddVersionIntCourseTable		 1
:		2 3
	Migration		4 =
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str 
,  
table 
: 
$str  
,  !
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$num 
)  
;  !
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str 
,  
table 
: 
$str  
)  !
;! "
} 	
} 
} �U
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628035240_AddSateAndPropsForCourseVersion.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 +
AddSateAndPropsForCourseVersion		 8
:		9 :
	Migration		; D
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str %
,% &
table 
: 
$str /
,/ 0
type 
: 
$str 
, 
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str %
,% &
table 
: 
$str '
,' (
type 
: 
$str 
, 
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str %
,% &
table 
: 
$str .
,. /
type 
: 
$str 
, 
nullable 
: 
true 
) 
;  
migrationBuilder   
.   
CreateTable   (
(  ( )
name!! 
:!! 
$str!! 2
,!!2 3
columns"" 
:"" 
table"" 
=>"" !
new""" %
{## 
Id$$ 
=$$ 
table$$ 
.$$ 
Column$$ %
<$$% &
Guid$$& *
>$$* +
($$+ ,
type$$, 0
:$$0 1
$str$$2 D
,$$D E
nullable$$F N
:$$N O
false$$P U
)$$U V
,$$V W"
CourseSectionVersionId%% *
=%%+ ,
table%%- 2
.%%2 3
Column%%3 9
<%%9 :
Guid%%: >
>%%> ?
(%%? @
type%%@ D
:%%D E
$str%%F X
,%%X Y
nullable%%Z b
:%%b c
true%%d h
)%%h i
,%%i j
Status&& 
=&& 
table&& "
.&&" #
Column&&# )
<&&) *
int&&* -
>&&- .
(&&. /
type&&/ 3
:&&3 4
$str&&5 :
,&&: ;
nullable&&< D
:&&D E
false&&F K
)&&K L
,&&L M

CreateTime'' 
=''  
table''! &
.''& '
Column''' -
<''- .
DateTime''. 6
>''6 7
(''7 8
type''8 <
:''< =
$str''> I
,''I J
nullable''K S
:''S T
false''U Z
)''Z [
}(( 
,(( 
constraints)) 
:)) 
table)) "
=>))# %
{** 
table++ 
.++ 

PrimaryKey++ $
(++$ %
$str++% D
,++D E
x++F G
=>++H J
x++K L
.++L M
Id++M O
)++O P
;++P Q
table,, 
.,, 

ForeignKey,, $
(,,$ %
name-- 
:-- 
$str-- j
,--j k
column.. 
:.. 
x..  !
=>.." $
x..% &
...& '"
CourseSectionVersionId..' =
,..= >
principalTable// &
://& '
$str//( ?
,//? @
principalColumn00 '
:00' (
$str00) -
)00- .
;00. /
}11 
)11 
;11 
migrationBuilder33 
.33 
CreateTable33 (
(33( )
name44 
:44 
$str44 3
,443 4
columns55 
:55 
table55 
=>55 !
new55" %
{66 
Id77 
=77 
table77 
.77 
Column77 %
<77% &
Guid77& *
>77* +
(77+ ,
type77, 0
:770 1
$str772 D
,77D E
nullable77F N
:77N O
false77P U
)77U V
,77V W#
SectionDetailsVersionId88 +
=88, -
table88. 3
.883 4
Column884 :
<88: ;
Guid88; ?
>88? @
(88@ A
type88A E
:88E F
$str88G Y
,88Y Z
nullable88[ c
:88c d
true88e i
)88i j
,88j k
Status99 
=99 
table99 "
.99" #
Column99# )
<99) *
int99* -
>99- .
(99. /
type99/ 3
:993 4
$str995 :
,99: ;
nullable99< D
:99D E
false99F K
)99K L
,99L M

CreateTime:: 
=::  
table::! &
.::& '
Column::' -
<::- .
DateTime::. 6
>::6 7
(::7 8
type::8 <
:::< =
$str::> I
,::I J
nullable::K S
:::S T
false::U Z
)::Z [
};; 
,;; 
constraints<< 
:<< 
table<< "
=><<# %
{== 
table>> 
.>> 

PrimaryKey>> $
(>>$ %
$str>>% E
,>>E F
x>>G H
=>>>I K
x>>L M
.>>M N
Id>>N P
)>>P Q
;>>Q R
table?? 
.?? 

ForeignKey?? $
(??$ %
name@@ 
:@@ 
$str@@ m
,@@m n
columnAA 
:AA 
xAA  !
=>AA" $
xAA% &
.AA& '#
SectionDetailsVersionIdAA' >
,AA> ?
principalTableBB &
:BB& '
$strBB( @
,BB@ A
principalColumnCC '
:CC' (
$strCC) -
)CC- .
;CC. /
}DD 
)DD 
;DD 
migrationBuilderFF 
.FF 

UpdateDataFF '
(FF' (
tableGG 
:GG 
$strGG $
,GG$ %
	keyColumnHH 
:HH 
$strHH 
,HH  
keyValueII 
:II 
$strII +
,II+ ,
columnsJJ 
:JJ 
newJJ 
[JJ 
]JJ 
{JJ  
$strJJ! 3
,JJ3 4
$strJJ5 A
,JJA B
$strJJC Q
,JJQ R
$strJJS b
}JJc d
,JJd e
valuesKK 
:KK 
newKK 
objectKK "
[KK" #
]KK# $
{KK% &
$strKK' M
,KKM N
newKKO R
DateTimeKKS [
(KK[ \
$numKK\ `
,KK` a
$numKKb c
,KKc d
$numKKe g
,KKg h
$numKKi j
,KKj k
$numKKl n
,KKn o
$numKKp r
,KKr s
$numKKt w
,KKw x
DateTimeKind	KKy �
.
KK� �
Utc
KK� �
)
KK� �
.
KK� �
AddTicks
KK� �
(
KK� �
$num
KK� �
)
KK� �
,
KK� �
$str
KK� �
,
KK� �
$str
KK� �
}
KK� �
)
KK� �
;
KK� �
migrationBuilderMM 
.MM 
CreateIndexMM (
(MM( )
nameNN 
:NN 
$strNN L
,NNL M
tableOO 
:OO 
$strOO 3
,OO3 4
columnPP 
:PP 
$strPP 0
)PP0 1
;PP1 2
migrationBuilderRR 
.RR 
CreateIndexRR (
(RR( )
nameSS 
:SS 
$strSS N
,SSN O
tableTT 
:TT 
$strTT 4
,TT4 5
columnUU 
:UU 
$strUU 1
)UU1 2
;UU2 3
}VV 	
	protectedYY 
overrideYY 
voidYY 
DownYY  $
(YY$ %
MigrationBuilderYY% 5
migrationBuilderYY6 F
)YYF G
{ZZ 	
migrationBuilder[[ 
.[[ 
	DropTable[[ &
([[& '
name\\ 
:\\ 
$str\\ 2
)\\2 3
;\\3 4
migrationBuilder^^ 
.^^ 
	DropTable^^ &
(^^& '
name__ 
:__ 
$str__ 3
)__3 4
;__4 5
migrationBuilderaa 
.aa 

DropColumnaa '
(aa' (
namebb 
:bb 
$strbb %
,bb% &
tablecc 
:cc 
$strcc /
)cc/ 0
;cc0 1
migrationBuilderee 
.ee 

DropColumnee '
(ee' (
nameff 
:ff 
$strff %
,ff% &
tablegg 
:gg 
$strgg '
)gg' (
;gg( )
migrationBuilderii 
.ii 

DropColumnii '
(ii' (
namejj 
:jj 
$strjj %
,jj% &
tablekk 
:kk 
$strkk .
)kk. /
;kk/ 0
migrationBuildermm 
.mm 

UpdateDatamm '
(mm' (
tablenn 
:nn 
$strnn $
,nn$ %
	keyColumnoo 
:oo 
$stroo 
,oo  
keyValuepp 
:pp 
$strpp +
,pp+ ,
columnsqq 
:qq 
newqq 
[qq 
]qq 
{qq  
$strqq! 3
,qq3 4
$strqq5 A
,qqA B
$strqqC Q
,qqQ R
$strqqS b
}qqc d
,qqd e
valuesrr 
:rr 
newrr 
objectrr "
[rr" #
]rr# $
{rr% &
$strrr' M
,rrM N
newrrO R
DateTimerrS [
(rr[ \
$numrr\ `
,rr` a
$numrrb c
,rrc d
$numrre g
,rrg h
$numrri j
,rrj k
$numrrl n
,rrn o
$numrrp r
,rrr s
$numrrt w
,rrw x
DateTimeKind	rry �
.
rr� �
Utc
rr� �
)
rr� �
.
rr� �
AddTicks
rr� �
(
rr� �
$num
rr� �
)
rr� �
,
rr� �
$str
rr� �
,
rr� �
$str
rr� �
}
rr� �
)
rr� �
;
rr� �
}ss 	
}tt 
}uu ߟ
~D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628032028_AddCourseVersion.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 
AddCourseVersion		 )
:		* +
	Migration		, 5
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str &
,& '
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 D
,D E
nullableF N
:N O
falseP U
)U V
,V W
CourseVersionId #
=$ %
table& +
.+ ,
Column, 2
<2 3
Guid3 7
>7 8
(8 9
type9 =
:= >
$str? Q
,Q R
nullableS [
:[ \
true] a
)a b
,b c
Title 
= 
table !
.! "
Column" (
<( )
string) /
>/ 0
(0 1
type1 5
:5 6
$str7 F
,F G
nullableH P
:P Q
trueR V
)V W
,W X
Code 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 E
,E F
nullableG O
:O P
trueQ U
)U V
,V W
Description 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= L
,L M
nullableN V
:V W
trueX \
)\ ]
,] ^
LearningTime  
=! "
table# (
.( )
Column) /
</ 0
int0 3
>3 4
(4 5
type5 9
:9 :
$str; @
,@ A
nullableB J
:J K
falseL Q
)Q R
,R S
Price 
= 
table !
.! "
Column" (
<( )
double) /
>/ 0
(0 1
type1 5
:5 6
$str7 >
,> ?
nullable@ H
:H I
falseJ O
)O P
,P Q
OldPrice 
= 
table $
.$ %
Column% +
<+ ,
double, 2
>2 3
(3 4
type4 8
:8 9
$str: A
,A B
nullableC K
:K L
trueM Q
)Q R
,R S
CourseImgUrl  
=! "
table# (
.( )
Column) /
</ 0
string0 6
>6 7
(7 8
type8 <
:< =
$str> M
,M N
nullableO W
:W X
trueY ]
)] ^
,^ _
InstructorId  
=! "
table# (
.( )
Column) /
</ 0
Guid0 4
>4 5
(5 6
type6 :
:: ;
$str< N
,N O
nullableP X
:X Y
falseZ _
)_ `
,` a

CategoryId 
=  
table! &
.& '
Column' -
<- .
Guid. 2
>2 3
(3 4
type4 8
:8 9
$str: L
,L M
nullableN V
:V W
trueX \
)\ ]
,] ^
LevelId 
= 
table #
.# $
Column$ *
<* +
Guid+ /
>/ 0
(0 1
type1 5
:5 6
$str7 I
,I J
nullableK S
:S T
trueU Y
)Y Z
} 
, 
constraints 
: 
table "
=># %
{   
table!! 
.!! 

PrimaryKey!! $
(!!$ %
$str!!% 8
,!!8 9
x!!: ;
=>!!< >
x!!? @
.!!@ A
Id!!A C
)!!C D
;!!D E
table"" 
."" 

ForeignKey"" $
(""$ %
name## 
:## 
$str## I
,##I J
column$$ 
:$$ 
x$$  !
=>$$" $
x$$% &
.$$& '
CourseVersionId$$' 6
,$$6 7
principalTable%% &
:%%& '
$str%%( 1
,%%1 2
principalColumn&& '
:&&' (
$str&&) -
)&&- .
;&&. /
}'' 
)'' 
;'' 
migrationBuilder)) 
.)) 
CreateTable)) (
())( )
name** 
:** 
$str** -
,**- .
columns++ 
:++ 
table++ 
=>++ !
new++" %
{,, 
Id-- 
=-- 
table-- 
.-- 
Column-- %
<--% &
Guid--& *
>--* +
(--+ ,
type--, 0
:--0 1
$str--2 D
,--D E
nullable--F N
:--N O
false--P U
)--U V
,--V W
CourseVersionId.. #
=..$ %
table..& +
...+ ,
Column.., 2
<..2 3
Guid..3 7
>..7 8
(..8 9
type..9 =
:..= >
$str..? Q
,..Q R
nullable..S [
:..[ \
true..] a
)..a b
,..b c
CourseSectionId// #
=//$ %
table//& +
.//+ ,
Column//, 2
<//2 3
Guid//3 7
>//7 8
(//8 9
type//9 =
://= >
$str//? Q
,//Q R
nullable//S [
://[ \
true//] a
)//a b
,//b c
Title00 
=00 
table00 !
.00! "
Column00" (
<00( )
string00) /
>00/ 0
(000 1
type001 5
:005 6
$str007 F
,00F G
nullable00H P
:00P Q
true00R V
)00V W
,00W X
Description11 
=11  !
table11" '
.11' (
Column11( .
<11. /
string11/ 5
>115 6
(116 7
type117 ;
:11; <
$str11= L
,11L M
nullable11N V
:11V W
true11X \
)11\ ]
}22 
,22 
constraints33 
:33 
table33 "
=>33# %
{44 
table55 
.55 

PrimaryKey55 $
(55$ %
$str55% ?
,55? @
x55A B
=>55C E
x55F G
.55G H
Id55H J
)55J K
;55K L
table66 
.66 

ForeignKey66 $
(66$ %
name77 
:77 
$str77 W
,77W X
column88 
:88 
x88  !
=>88" $
x88% &
.88& '
CourseSectionId88' 6
,886 7
principalTable99 &
:99& '
$str99( 8
,998 9
principalColumn:: '
:::' (
$str::) -
)::- .
;::. /
table;; 
.;; 

ForeignKey;; $
(;;$ %
name<< 
:<< 
$str<< W
,<<W X
column== 
:== 
x==  !
=>==" $
x==% &
.==& '
CourseVersionId==' 6
,==6 7
principalTable>> &
:>>& '
$str>>( 8
,>>8 9
principalColumn?? '
:??' (
$str??) -
)??- .
;??. /
}@@ 
)@@ 
;@@ 
migrationBuilderBB 
.BB 
CreateTableBB (
(BB( )
nameCC 
:CC 
$strCC +
,CC+ ,
columnsDD 
:DD 
tableDD 
=>DD !
newDD" %
{EE 
IdFF 
=FF 
tableFF 
.FF 
ColumnFF %
<FF% &
GuidFF& *
>FF* +
(FF+ ,
typeFF, 0
:FF0 1
$strFF2 D
,FFD E
nullableFFF N
:FFN O
falseFFP U
)FFU V
,FFV W
CourseVersionIdGG #
=GG$ %
tableGG& +
.GG+ ,
ColumnGG, 2
<GG2 3
GuidGG3 7
>GG7 8
(GG8 9
typeGG9 =
:GG= >
$strGG? Q
,GGQ R
nullableGGS [
:GG[ \
trueGG] a
)GGa b
,GGb c
StatusHH 
=HH 
tableHH "
.HH" #
ColumnHH# )
<HH) *
intHH* -
>HH- .
(HH. /
typeHH/ 3
:HH3 4
$strHH5 :
,HH: ;
nullableHH< D
:HHD E
falseHHF K
)HHK L
,HHL M

CreateTimeII 
=II  
tableII! &
.II& '
ColumnII' -
<II- .
DateTimeII. 6
>II6 7
(II7 8
typeII8 <
:II< =
$strII> I
,III J
nullableIIK S
:IIS T
falseIIU Z
)IIZ [
}JJ 
,JJ 
constraintsKK 
:KK 
tableKK "
=>KK# %
{LL 
tableMM 
.MM 

PrimaryKeyMM $
(MM$ %
$strMM% =
,MM= >
xMM? @
=>MMA C
xMMD E
.MME F
IdMMF H
)MMH I
;MMI J
tableNN 
.NN 

ForeignKeyNN $
(NN$ %
nameOO 
:OO 
$strOO U
,OOU V
columnPP 
:PP 
xPP  !
=>PP" $
xPP% &
.PP& '
CourseVersionIdPP' 6
,PP6 7
principalTableQQ &
:QQ& '
$strQQ( 8
,QQ8 9
principalColumnRR '
:RR' (
$strRR) -
)RR- .
;RR. /
}SS 
)SS 
;SS 
migrationBuilderUU 
.UU 
CreateTableUU (
(UU( )
nameVV 
:VV 
$strVV .
,VV. /
columnsWW 
:WW 
tableWW 
=>WW !
newWW" %
{XX 
IdYY 
=YY 
tableYY 
.YY 
ColumnYY %
<YY% &
GuidYY& *
>YY* +
(YY+ ,
typeYY, 0
:YY0 1
$strYY2 D
,YYD E
nullableYYF N
:YYN O
falseYYP U
)YYU V
,YYV W"
CourseSectionVersionIdZZ *
=ZZ+ ,
tableZZ- 2
.ZZ2 3
ColumnZZ3 9
<ZZ9 :
GuidZZ: >
>ZZ> ?
(ZZ? @
typeZZ@ D
:ZZD E
$strZZF X
,ZZX Y
nullableZZZ b
:ZZb c
trueZZd h
)ZZh i
,ZZi j
SectionDetailsId[[ $
=[[% &
table[[' ,
.[[, -
Column[[- 3
<[[3 4
Guid[[4 8
>[[8 9
([[9 :
type[[: >
:[[> ?
$str[[@ R
,[[R S
nullable[[T \
:[[\ ]
false[[^ c
)[[c d
,[[d e
Name\\ 
=\\ 
table\\  
.\\  !
Column\\! '
<\\' (
string\\( .
>\\. /
(\\/ 0
type\\0 4
:\\4 5
$str\\6 E
,\\E F
nullable\\G O
:\\O P
true\\Q U
)\\U V
,\\V W
VideoUrl]] 
=]] 
table]] $
.]]$ %
Column]]% +
<]]+ ,
string]], 2
>]]2 3
(]]3 4
type]]4 8
:]]8 9
$str]]: I
,]]I J
nullable]]K S
:]]S T
true]]U Y
)]]Y Z
,]]Z [
SlideUrk^^ 
=^^ 
table^^ $
.^^$ %
Column^^% +
<^^+ ,
string^^, 2
>^^2 3
(^^3 4
type^^4 8
:^^8 9
$str^^: I
,^^I J
nullable^^K S
:^^S T
true^^U Y
)^^Y Z
,^^Z [
DocsUrl__ 
=__ 
table__ #
.__# $
Column__$ *
<__* +
string__+ 1
>__1 2
(__2 3
type__3 7
:__7 8
$str__9 H
,__H I
nullable__J R
:__R S
true__T X
)__X Y
,__Y Z
Type`` 
=`` 
table``  
.``  !
Column``! '
<``' (
int``( +
>``+ ,
(``, -
type``- 1
:``1 2
$str``3 8
,``8 9
nullable``: B
:``B C
true``D H
)``H I
}aa 
,aa 
constraintsbb 
:bb 
tablebb "
=>bb# %
{cc 
tabledd 
.dd 

PrimaryKeydd $
(dd$ %
$strdd% @
,dd@ A
xddB C
=>ddD F
xddG H
.ddH I
IdddI K
)ddK L
;ddL M
tableee 
.ee 

ForeignKeyee $
(ee$ %
nameff 
:ff 
$strff f
,fff g
columngg 
:gg 
xgg  !
=>gg" $
xgg% &
.gg& '"
CourseSectionVersionIdgg' =
,gg= >
principalTablehh &
:hh& '
$strhh( ?
,hh? @
principalColumnii '
:ii' (
$strii) -
)ii- .
;ii. /
tablejj 
.jj 

ForeignKeyjj $
(jj$ %
namekk 
:kk 
$strkk Y
,kkY Z
columnll 
:ll 
xll  !
=>ll" $
xll% &
.ll& '
SectionDetailsIdll' 7
,ll7 8
principalTablemm &
:mm& '
$strmm( 8
,mm8 9
principalColumnnn '
:nn' (
$strnn) -
,nn- .
onDeleteoo  
:oo  !
ReferentialActionoo" 3
.oo3 4
Cascadeoo4 ;
)oo; <
;oo< =
}pp 
)pp 
;pp 
migrationBuilderrr 
.rr 

UpdateDatarr '
(rr' (
tabless 
:ss 
$strss $
,ss$ %
	keyColumntt 
:tt 
$strtt 
,tt  
keyValueuu 
:uu 
$struu +
,uu+ ,
columnsvv 
:vv 
newvv 
[vv 
]vv 
{vv  
$strvv! 3
,vv3 4
$strvv5 A
,vvA B
$strvvC Q
,vvQ R
$strvvS b
}vvc d
,vvd e
valuesww 
:ww 
newww 
objectww "
[ww" #
]ww# $
{ww% &
$strww' M
,wwM N
newwwO R
DateTimewwS [
(ww[ \
$numww\ `
,ww` a
$numwwb c
,wwc d
$numwwe g
,wwg h
$numwwi j
,wwj k
$numwwl n
,wwn o
$numwwp r
,wwr s
$numwwt w
,www x
DateTimeKind	wwy �
.
ww� �
Utc
ww� �
)
ww� �
.
ww� �
AddTicks
ww� �
(
ww� �
$num
ww� �
)
ww� �
,
ww� �
$str
ww� �
,
ww� �
$str
ww� �
}
ww� �
)
ww� �
;
ww� �
migrationBuilderyy 
.yy 
CreateIndexyy (
(yy( )
namezz 
:zz 
$strzz @
,zz@ A
table{{ 
:{{ 
$str{{ .
,{{. /
column|| 
:|| 
$str|| )
)||) *
;||* +
migrationBuilder~~ 
.~~ 
CreateIndex~~ (
(~~( )
name 
: 
$str @
,@ A
table
�� 
:
�� 
$str
�� .
,
��. /
column
�� 
:
�� 
$str
�� )
)
��) *
;
��* +
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 9
,
��9 :
table
�� 
:
�� 
$str
�� '
,
��' (
column
�� 
:
�� 
$str
�� )
)
��) *
;
��* +
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� >
,
��> ?
table
�� 
:
�� 
$str
�� ,
,
��, -
column
�� 
:
�� 
$str
�� )
)
��) *
;
��* +
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� H
,
��H I
table
�� 
:
�� 
$str
�� /
,
��/ 0
column
�� 
:
�� 
$str
�� 0
)
��0 1
;
��1 2
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� B
,
��B C
table
�� 
:
�� 
$str
�� /
,
��/ 0
column
�� 
:
�� 
$str
�� *
)
��* +
;
��+ ,
}
�� 	
	protected
�� 
override
�� 
void
�� 
Down
��  $
(
��$ %
MigrationBuilder
��% 5
migrationBuilder
��6 F
)
��F G
{
�� 	
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� +
)
��+ ,
;
��, -
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� .
)
��. /
;
��/ 0
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� -
)
��- .
;
��. /
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� &
)
��& '
;
��' (
migrationBuilder
�� 
.
�� 

UpdateData
�� '
(
��' (
table
�� 
:
�� 
$str
�� $
,
��$ %
	keyColumn
�� 
:
�� 
$str
�� 
,
��  
keyValue
�� 
:
�� 
$str
�� +
,
��+ ,
columns
�� 
:
�� 
new
�� 
[
�� 
]
�� 
{
��  
$str
��! 3
,
��3 4
$str
��5 A
,
��A B
$str
��C Q
,
��Q R
$str
��S b
}
��c d
,
��d e
values
�� 
:
�� 
new
�� 
object
�� "
[
��" #
]
��# $
{
��% &
$str
��' M
,
��M N
new
��O R
DateTime
��S [
(
��[ \
$num
��\ `
,
��` a
$num
��b c
,
��c d
$num
��e g
,
��g h
$num
��i j
,
��j k
$num
��l n
,
��n o
$num
��p r
,
��r s
$num
��t u
,
��u v
DateTimeKind��w �
.��� �
Utc��� �
)��� �
.��� �
AddTicks��� �
(��� �
$num��� �
)��� �
,��� �
$str��� �
,��� �
$str��� �
}��� �
)��� �
;��� �
}
�� 	
}
�� 
}�� �l
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628031259_AddStateForCourse.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 
AddStateForCourse		 *
:		+ ,
	Migration		- 6
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 

DeleteData '
(' (
table 
: 
$str (
,( )

keyColumns 
: 
new 
[  
]  !
{" #
$str$ ,
,, -
$str. 6
}7 8
,8 9
	keyValues 
: 
new 
object %
[% &
]& '
{( )
$str* P
,P Q
$strR c
}d e
)e f
;f g
migrationBuilder 
. 

DeleteData '
(' (
table 
: 
$str $
,$ %
	keyColumn 
: 
$str 
,  
keyValue 
: 
$str +
)+ ,
;, -
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str #
,# $
table 
: 
$str  
,  !
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str %
,% &
table   
:   
$str    
,    !
type!! 
:!! 
$str!! !
,!!! "
nullable"" 
:"" 
true"" 
)"" 
;""  
migrationBuilder$$ 
.$$ 
	AddColumn$$ &
<$$& '
string$$' -
>$$- .
($$. /
name%% 
:%% 
$str%% %
,%%% &
table&& 
:&& 
$str&&  
,&&  !
type'' 
:'' 
$str'' %
,''% &
nullable(( 
:(( 
true(( 
)(( 
;((  
migrationBuilder** 
.** 
	AddColumn** &
<**& '
DateTime**' /
>**/ 0
(**0 1
name++ 
:++ 
$str++ '
,++' (
table,, 
:,, 
$str,,  
,,,  !
type-- 
:-- 
$str-- !
,--! "
nullable.. 
:.. 
true.. 
).. 
;..  
migrationBuilder00 
.00 
	AddColumn00 &
<00& '
int00' *
>00* +
(00+ ,
name11 
:11 
$str11 
,11 
table22 
:22 
$str22  
,22  !
type33 
:33 
$str33 
,33 
nullable44 
:44 
false44 
,44  
defaultValue55 
:55 
$num55 
)55  
;55  !
migrationBuilder77 
.77 

InsertData77 '
(77' (
table88 
:88 
$str88 $
,88$ %
columns99 
:99 
new99 
[99 
]99 
{99  
$str99! %
,99% &
$str99' :
,99: ;
$str99< E
,99E F
$str99G R
,99R S
$str99T _
,99_ `
$str99a s
,99s t
$str99u ~
,99~ 
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
,
99� �
$str
99� �
}
99� �
,
99� �
values:: 
::: 
new:: 
object:: "
[::" #
]::# $
{::% &
$str::' 8
,::8 9
$num::: ;
,::; <
$str::= K
,::K L
$str::M m
,::m n
new::o r
DateTime::s {
(::{ |
$num	::| �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
DateTimeKind
::� �
.
::� �
Unspecified
::� �
)
::� �
,
::� �
$str
::� �
,
::� �
$str
::� �
,
::� �
new
::� �
DateTime
::� �
(
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
DateTimeKind
::� �
.
::� �
Utc
::� �
)
::� �
.
::� �
AddTicks
::� �
(
::� �
$num
::� �
)
::� �
,
::� �
$str
::� �
,
::� �
true
::� �
,
::� �
$str
::� �
,
::� �
$str
::� �
,
::� �
true
::� �
,
::� �
null
::� �
,
::� �
$str
::� �
,
::� �
$str
::� �
,
::� �
$str
::� �
,
::� �
$str
::� �
,
::� �
true
::� �
,
::� �
$str
::� �
,
::� �
$str
::� �
,
::� �
false
::� �
,
::� �
new
::� �
DateTime
::� �
(
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
$num
::� �
,
::� �
DateTimeKind
::� �
.
::� �
Unspecified
::� �
)
::� �
,
::� �
$str
::� �
}
::� �
)
::� �
;
::� �
migrationBuilder<< 
.<< 

InsertData<< '
(<<' (
table== 
:== 
$str== (
,==( )
columns>> 
:>> 
new>> 
[>> 
]>> 
{>>  
$str>>! )
,>>) *
$str>>+ 3
}>>4 5
,>>5 6
values?? 
:?? 
new?? 
object?? "
[??" #
]??# $
{??% &
$str??' M
,??M N
$str??O `
}??a b
)??b c
;??c d
}@@ 	
	protectedCC 
overrideCC 
voidCC 
DownCC  $
(CC$ %
MigrationBuilderCC% 5
migrationBuilderCC6 F
)CCF G
{DD 	
migrationBuilderEE 
.EE 

DeleteDataEE '
(EE' (
tableFF 
:FF 
$strFF (
,FF( )

keyColumnsGG 
:GG 
newGG 
[GG  
]GG  !
{GG" #
$strGG$ ,
,GG, -
$strGG. 6
}GG7 8
,GG8 9
	keyValuesHH 
:HH 
newHH 
objectHH %
[HH% &
]HH& '
{HH( )
$strHH* P
,HHP Q
$strHHR c
}HHd e
)HHe f
;HHf g
migrationBuilderJJ 
.JJ 

DeleteDataJJ '
(JJ' (
tableKK 
:KK 
$strKK $
,KK$ %
	keyColumnLL 
:LL 
$strLL 
,LL  
keyValueMM 
:MM 
$strMM +
)MM+ ,
;MM, -
migrationBuilderOO 
.OO 

DropColumnOO '
(OO' (
namePP 
:PP 
$strPP #
,PP# $
tableQQ 
:QQ 
$strQQ  
)QQ  !
;QQ! "
migrationBuilderSS 
.SS 

DropColumnSS '
(SS' (
nameTT 
:TT 
$strTT %
,TT% &
tableUU 
:UU 
$strUU  
)UU  !
;UU! "
migrationBuilderWW 
.WW 

DropColumnWW '
(WW' (
nameXX 
:XX 
$strXX %
,XX% &
tableYY 
:YY 
$strYY  
)YY  !
;YY! "
migrationBuilder[[ 
.[[ 

DropColumn[[ '
([[' (
name\\ 
:\\ 
$str\\ '
,\\' (
table]] 
:]] 
$str]]  
)]]  !
;]]! "
migrationBuilder__ 
.__ 

DropColumn__ '
(__' (
name`` 
:`` 
$str`` 
,`` 
tableaa 
:aa 
$straa  
)aa  !
;aa! "
migrationBuildercc 
.cc 

InsertDatacc '
(cc' (
tabledd 
:dd 
$strdd $
,dd$ %
columnsee 
:ee 
newee 
[ee 
]ee 
{ee  
$stree! %
,ee% &
$stree' :
,ee: ;
$stree< E
,eeE F
$streeG R
,eeR S
$streeT _
,ee_ `
$streea s
,ees t
$streeu ~
,ee~ 
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
,
ee� �
$str
ee� �
}
ee� �
,
ee� �
valuesff 
:ff 
newff 
objectff "
[ff" #
]ff# $
{ff% &
$strff' 8
,ff8 9
$numff: ;
,ff; <
$strff= K
,ffK L
$strffM m
,ffm n
newffo r
DateTimeffs {
(ff{ |
$num	ff| �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
DateTimeKind
ff� �
.
ff� �
Unspecified
ff� �
)
ff� �
,
ff� �
$str
ff� �
,
ff� �
$str
ff� �
,
ff� �
new
ff� �
DateTime
ff� �
(
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
DateTimeKind
ff� �
.
ff� �
Utc
ff� �
)
ff� �
.
ff� �
AddTicks
ff� �
(
ff� �
$num
ff� �
)
ff� �
,
ff� �
$str
ff� �
,
ff� �
true
ff� �
,
ff� �
$str
ff� �
,
ff� �
$str
ff� �
,
ff� �
true
ff� �
,
ff� �
null
ff� �
,
ff� �
$str
ff� �
,
ff� �
$str
ff� �
,
ff� �
$str
ff� �
,
ff� �
$str
ff� �
,
ff� �
true
ff� �
,
ff� �
$str
ff� �
,
ff� �
$str
ff� �
,
ff� �
false
ff� �
,
ff� �
new
ff� �
DateTime
ff� �
(
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
$num
ff� �
,
ff� �
DateTimeKind
ff� �
.
ff� �
Utc
ff� �
)
ff� �
.
ff� �
AddTicks
ff� �
(
ff� �
$num
ff� �
)
ff� �
,
ff� �
$str
ff� �
}
ff� �
)
ff� �
;
ff� �
migrationBuilderhh 
.hh 

InsertDatahh '
(hh' (
tableii 
:ii 
$strii (
,ii( )
columnsjj 
:jj 
newjj 
[jj 
]jj 
{jj  
$strjj! )
,jj) *
$strjj+ 3
}jj4 5
,jj5 6
valueskk 
:kk 
newkk 
objectkk "
[kk" #
]kk# $
{kk% &
$strkk' M
,kkM N
$strkkO `
}kka b
)kkb c
;kkc d
}ll 	
}mm 
}nn �:
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628030144_DeleteStateCourse.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 
DeleteStateCourse		 *
:		+ ,
	Migration		- 6
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str #
,# $
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str !
,! "
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str !
,! "
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str #
,# $
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table   
:   
$str    
)    !
;  ! "
migrationBuilder"" 
."" 

DropColumn"" '
(""' (
name## 
:## 
$str## $
,##$ %
table$$ 
:$$ 
$str$$  
)$$  !
;$$! "
migrationBuilder&& 
.&& 

DropColumn&& '
(&&' (
name'' 
:'' 
$str'' 
,'' 
table(( 
:(( 
$str((  
)((  !
;((! "
migrationBuilder** 
.** 

DropColumn** '
(**' (
name++ 
:++ 
$str++ #
,++# $
table,, 
:,, 
$str,,  
),,  !
;,,! "
migrationBuilder.. 
... 

DropColumn.. '
(..' (
name// 
:// 
$str// !
,//! "
table00 
:00 
$str00  
)00  !
;00! "
migrationBuilder22 
.22 
	AddColumn22 &
<22& '
double22' -
>22- .
(22. /
name33 
:33 
$str33  
,33  !
table44 
:44 
$str44  
,44  !
type55 
:55 
$str55 
,55 
nullable66 
:66 
true66 
)66 
;66  
}77 	
	protected:: 
override:: 
void:: 
Down::  $
(::$ %
MigrationBuilder::% 5
migrationBuilder::6 F
)::F G
{;; 	
migrationBuilder<< 
.<< 

DropColumn<< '
(<<' (
name== 
:== 
$str==  
,==  !
table>> 
:>> 
$str>>  
)>>  !
;>>! "
migrationBuilder@@ 
.@@ 
	AddColumn@@ &
<@@& '
DateTime@@' /
>@@/ 0
(@@0 1
nameAA 
:AA 
$strAA #
,AA# $
tableBB 
:BB 
$strBB  
,BB  !
typeCC 
:CC 
$strCC !
,CC! "
nullableDD 
:DD 
trueDD 
)DD 
;DD  
migrationBuilderFF 
.FF 
	AddColumnFF &
<FF& '
stringFF' -
>FF- .
(FF. /
nameGG 
:GG 
$strGG !
,GG! "
tableHH 
:HH 
$strHH  
,HH  !
typeII 
:II 
$strII %
,II% &
nullableJJ 
:JJ 
trueJJ 
)JJ 
;JJ  
migrationBuilderLL 
.LL 
	AddColumnLL &
<LL& '
stringLL' -
>LL- .
(LL. /
nameMM 
:MM 
$strMM !
,MM! "
tableNN 
:NN 
$strNN  
,NN  !
typeOO 
:OO 
$strOO %
,OO% &
nullablePP 
:PP 
truePP 
)PP 
;PP  
migrationBuilderRR 
.RR 
	AddColumnRR &
<RR& '
DateTimeRR' /
>RR/ 0
(RR0 1
nameSS 
:SS 
$strSS #
,SS# $
tableTT 
:TT 
$strTT  
,TT  !
typeUU 
:UU 
$strUU !
,UU! "
nullableVV 
:VV 
trueVV 
)VV 
;VV  
migrationBuilderXX 
.XX 
	AddColumnXX &
<XX& '
stringXX' -
>XX- .
(XX. /
nameYY 
:YY 
$strYY "
,YY" #
tableZZ 
:ZZ 
$strZZ  
,ZZ  !
type[[ 
:[[ 
$str[[ %
,[[% &
nullable\\ 
:\\ 
true\\ 
)\\ 
;\\  
migrationBuilder^^ 
.^^ 
	AddColumn^^ &
<^^& '
DateTime^^' /
>^^/ 0
(^^0 1
name__ 
:__ 
$str__ $
,__$ %
table`` 
:`` 
$str``  
,``  !
typeaa 
:aa 
$straa !
,aa! "
nullablebb 
:bb 
truebb 
)bb 
;bb  
migrationBuilderdd 
.dd 
	AddColumndd &
<dd& '
intdd' *
>dd* +
(dd+ ,
nameee 
:ee 
$stree 
,ee 
tableff 
:ff 
$strff  
,ff  !
typegg 
:gg 
$strgg 
,gg 
nullablehh 
:hh 
falsehh 
,hh  
defaultValueii 
:ii 
$numii 
)ii  
;ii  !
migrationBuilderkk 
.kk 
	AddColumnkk &
<kk& '
DateTimekk' /
>kk/ 0
(kk0 1
namell 
:ll 
$strll #
,ll# $
tablemm 
:mm 
$strmm  
,mm  !
typenn 
:nn 
$strnn !
,nn! "
nullableoo 
:oo 
trueoo 
)oo 
;oo  
migrationBuilderqq 
.qq 
	AddColumnqq &
<qq& '
stringqq' -
>qq- .
(qq. /
namerr 
:rr 
$strrr !
,rr! "
tabless 
:ss 
$strss  
,ss  !
typett 
:tt 
$strtt %
,tt% &
nullableuu 
:uu 
trueuu 
)uu 
;uu  
}ww 	
}xx 
}yy �:
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240625020837_AddMorePropsCourses.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 
AddMorePropsCourses		 ,
:		- .
	Migration		/ 8
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str #
,# $
table 
: 
$str  
,  !
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str !
,! "
table 
: 
$str  
,  !
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str !
,! "
table 
: 
$str  
,  !
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
migrationBuilder   
.   
	AddColumn   &
<  & '
DateTime  ' /
>  / 0
(  0 1
name!! 
:!! 
$str!! #
,!!# $
table"" 
:"" 
$str""  
,""  !
type## 
:## 
$str## !
,##! "
nullable$$ 
:$$ 
true$$ 
)$$ 
;$$  
migrationBuilder&& 
.&& 
	AddColumn&& &
<&&& '
int&&' *
>&&* +
(&&+ ,
name'' 
:'' 
$str'' $
,''$ %
table(( 
:(( 
$str((  
,((  !
type)) 
:)) 
$str)) 
,)) 
nullable** 
:** 
false** 
,**  
defaultValue++ 
:++ 
$num++ 
)++  
;++  !
migrationBuilder-- 
.-- 
	AddColumn-- &
<--& '
string--' -
>--- .
(--. /
name.. 
:.. 
$str.. "
,.." #
table// 
:// 
$str//  
,//  !
type00 
:00 
$str00 %
,00% &
nullable11 
:11 
true11 
)11 
;11  
migrationBuilder33 
.33 
	AddColumn33 &
<33& '
DateTime33' /
>33/ 0
(330 1
name44 
:44 
$str44 $
,44$ %
table55 
:55 
$str55  
,55  !
type66 
:66 
$str66 !
,66! "
nullable77 
:77 
true77 
)77 
;77  
migrationBuilder99 
.99 
	AddColumn99 &
<99& '
int99' *
>99* +
(99+ ,
name:: 
::: 
$str:: 
,:: 
table;; 
:;; 
$str;;  
,;;  !
type<< 
:<< 
$str<< 
,<< 
nullable== 
:== 
false== 
,==  
defaultValue>> 
:>> 
$num>> 
)>>  
;>>  !
migrationBuilder@@ 
.@@ 
	AddColumn@@ &
<@@& '
DateTime@@' /
>@@/ 0
(@@0 1
nameAA 
:AA 
$strAA #
,AA# $
tableBB 
:BB 
$strBB  
,BB  !
typeCC 
:CC 
$strCC !
,CC! "
nullableDD 
:DD 
trueDD 
)DD 
;DD  
migrationBuilderFF 
.FF 
	AddColumnFF &
<FF& '
stringFF' -
>FF- .
(FF. /
nameGG 
:GG 
$strGG !
,GG! "
tableHH 
:HH 
$strHH  
,HH  !
typeII 
:II 
$strII %
,II% &
nullableJJ 
:JJ 
trueJJ 
)JJ 
;JJ  
}LL 	
	protectedOO 
overrideOO 
voidOO 
DownOO  $
(OO$ %
MigrationBuilderOO% 5
migrationBuilderOO6 F
)OOF G
{PP 	
migrationBuilderQQ 
.QQ 

DropColumnQQ '
(QQ' (
nameRR 
:RR 
$strRR #
,RR# $
tableSS 
:SS 
$strSS  
)SS  !
;SS! "
migrationBuilderUU 
.UU 

DropColumnUU '
(UU' (
nameVV 
:VV 
$strVV !
,VV! "
tableWW 
:WW 
$strWW  
)WW  !
;WW! "
migrationBuilderYY 
.YY 

DropColumnYY '
(YY' (
nameZZ 
:ZZ 
$strZZ !
,ZZ! "
table[[ 
:[[ 
$str[[  
)[[  !
;[[! "
migrationBuilder]] 
.]] 

DropColumn]] '
(]]' (
name^^ 
:^^ 
$str^^ #
,^^# $
table__ 
:__ 
$str__  
)__  !
;__! "
migrationBuilderaa 
.aa 

DropColumnaa '
(aa' (
namebb 
:bb 
$strbb $
,bb$ %
tablecc 
:cc 
$strcc  
)cc  !
;cc! "
migrationBuilderee 
.ee 

DropColumnee '
(ee' (
nameff 
:ff 
$strff "
,ff" #
tablegg 
:gg 
$strgg  
)gg  !
;gg! "
migrationBuilderii 
.ii 

DropColumnii '
(ii' (
namejj 
:jj 
$strjj $
,jj$ %
tablekk 
:kk 
$strkk  
)kk  !
;kk! "
migrationBuildermm 
.mm 

DropColumnmm '
(mm' (
namenn 
:nn 
$strnn 
,nn 
tableoo 
:oo 
$stroo  
)oo  !
;oo! "
migrationBuilderqq 
.qq 

DropColumnqq '
(qq' (
namerr 
:rr 
$strrr #
,rr# $
tabless 
:ss 
$strss  
)ss  !
;ss! "
migrationBuilderuu 
.uu 

DropColumnuu '
(uu' (
namevv 
:vv 
$strvv !
,vv! "
tableww 
:ww 
$strww  
)ww  !
;ww! "
}yy 	
}zz 
}{{ �(
}D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240625015912_ModifiedCourses.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 
ModifiedCourses		 (
:		) *
	Migration		+ 4
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str  
,  !
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str  
,  !
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str $
,$ %
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str 
, 
table   
:   
$str    
,    !
type!! 
:!! 
$str!! %
,!!% &
nullable"" 
:"" 
false"" 
,""  
defaultValue## 
:## 
$str##  
)##  !
;##! "
}%% 	
	protected(( 
override(( 
void(( 
Down((  $
((($ %
MigrationBuilder((% 5
migrationBuilder((6 F
)((F G
{)) 	
migrationBuilder** 
.** 

DropColumn** '
(**' (
name++ 
:++ 
$str++ 
,++ 
table,, 
:,, 
$str,,  
),,  !
;,,! "
migrationBuilder.. 
... 
	AddColumn.. &
<..& '
DateTime..' /
>../ 0
(..0 1
name// 
:// 
$str//  
,//  !
table00 
:00 
$str00  
,00  !
type11 
:11 
$str11 !
,11! "
nullable22 
:22 
false22 
,22  
defaultValue33 
:33 
new33 !
DateTime33" *
(33* +
$num33+ ,
,33, -
$num33. /
,33/ 0
$num331 2
,332 3
$num334 5
,335 6
$num337 8
,338 9
$num33: ;
,33; <
$num33= >
,33> ?
DateTimeKind33@ L
.33L M
Unspecified33M X
)33X Y
)33Y Z
;33Z [
migrationBuilder55 
.55 
	AddColumn55 &
<55& '
bool55' +
>55+ ,
(55, -
name66 
:66 
$str66 "
,66" #
table77 
:77 
$str77  
,77  !
type88 
:88 
$str88 
,88 
nullable99 
:99 
false99 
,99  
defaultValue:: 
::: 
false:: #
)::# $
;::$ %
migrationBuilder<< 
.<< 
	AddColumn<< &
<<<& '
bool<<' +
><<+ ,
(<<, -
name== 
:== 
$str==  
,==  !
table>> 
:>> 
$str>>  
,>>  !
type?? 
:?? 
$str?? 
,?? 
nullable@@ 
:@@ 
false@@ 
,@@  
defaultValueAA 
:AA 
falseAA #
)AA# $
;AA$ %
migrationBuilderCC 
.CC 
	AddColumnCC &
<CC& '
DateTimeCC' /
>CC/ 0
(CC0 1
nameDD 
:DD 
$strDD $
,DD$ %
tableEE 
:EE 
$strEE  
,EE  !
typeFF 
:FF 
$strFF !
,FF! "
nullableGG 
:GG 
falseGG 
,GG  
defaultValueHH 
:HH 
newHH !
DateTimeHH" *
(HH* +
$numHH+ ,
,HH, -
$numHH. /
,HH/ 0
$numHH1 2
,HH2 3
$numHH4 5
,HH5 6
$numHH7 8
,HH8 9
$numHH: ;
,HH; <
$numHH= >
,HH> ?
DateTimeKindHH@ L
.HHL M
UnspecifiedHHM X
)HHX Y
)HHY Z
;HHZ [
}II 	
}JJ 
}KK ��
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240625015607_ModifiedBaseEntity.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 
ModifiedBaseEntity		 +
:		, -
	Migration		. 7
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
AlterColumn (
<( )
DateTime) 1
>1 2
(2 3
name 
: 
$str "
," #
table 
: 
$str *
,* +
type 
: 
$str !
,! "
nullable 
: 
true 
, 

oldClrType 
: 
typeof "
(" #
DateTime# +
)+ ,
,, -
oldType 
: 
$str $
)$ %
;% &
migrationBuilder 
. 
AlterColumn (
<( )
string) /
>/ 0
(0 1
name 
: 
$str  
,  !
table 
: 
$str *
,* +
type 
: 
$str %
,% &
nullable 
: 
true 
, 

oldClrType 
: 
typeof "
(" #
string# )
)) *
,* +
oldType 
: 
$str (
)( )
;) *
migrationBuilder 
. 
AlterColumn (
<( )
DateTime) 1
>1 2
(2 3
name 
: 
$str "
," #
table   
:   
$str   *
,  * +
type!! 
:!! 
$str!! !
,!!! "
nullable"" 
:"" 
true"" 
,"" 

oldClrType## 
:## 
typeof## "
(##" #
DateTime### +
)##+ ,
,##, -
oldType$$ 
:$$ 
$str$$ $
)$$$ %
;$$% &
migrationBuilder&& 
.&& 
AlterColumn&& (
<&&( )
string&&) /
>&&/ 0
(&&0 1
name'' 
:'' 
$str''  
,''  !
table(( 
:(( 
$str(( *
,((* +
type)) 
:)) 
$str)) %
,))% &
nullable** 
:** 
true** 
,** 

oldClrType++ 
:++ 
typeof++ "
(++" #
string++# )
)++) *
,++* +
oldType,, 
:,, 
$str,, (
),,( )
;,,) *
migrationBuilder.. 
... 
AlterColumn.. (
<..( )
DateTime..) 1
>..1 2
(..2 3
name// 
:// 
$str// "
,//" #
table00 
:00 
$str00 +
,00+ ,
type11 
:11 
$str11 !
,11! "
nullable22 
:22 
true22 
,22 

oldClrType33 
:33 
typeof33 "
(33" #
DateTime33# +
)33+ ,
,33, -
oldType44 
:44 
$str44 $
)44$ %
;44% &
migrationBuilder66 
.66 
AlterColumn66 (
<66( )
string66) /
>66/ 0
(660 1
name77 
:77 
$str77  
,77  !
table88 
:88 
$str88 +
,88+ ,
type99 
:99 
$str99 %
,99% &
nullable:: 
::: 
true:: 
,:: 

oldClrType;; 
:;; 
typeof;; "
(;;" #
string;;# )
);;) *
,;;* +
oldType<< 
:<< 
$str<< (
)<<( )
;<<) *
migrationBuilder>> 
.>> 
AlterColumn>> (
<>>( )
DateTime>>) 1
>>>1 2
(>>2 3
name?? 
:?? 
$str?? "
,??" #
table@@ 
:@@ 
$str@@ +
,@@+ ,
typeAA 
:AA 
$strAA !
,AA! "
nullableBB 
:BB 
trueBB 
,BB 

oldClrTypeCC 
:CC 
typeofCC "
(CC" #
DateTimeCC# +
)CC+ ,
,CC, -
oldTypeDD 
:DD 
$strDD $
)DD$ %
;DD% &
migrationBuilderFF 
.FF 
AlterColumnFF (
<FF( )
stringFF) /
>FF/ 0
(FF0 1
nameGG 
:GG 
$strGG  
,GG  !
tableHH 
:HH 
$strHH +
,HH+ ,
typeII 
:II 
$strII %
,II% &
nullableJJ 
:JJ 
trueJJ 
,JJ 

oldClrTypeKK 
:KK 
typeofKK "
(KK" #
stringKK# )
)KK) *
,KK* +
oldTypeLL 
:LL 
$strLL (
)LL( )
;LL) *
migrationBuilderNN 
.NN 
AlterColumnNN (
<NN( )
DateTimeNN) 1
>NN1 2
(NN2 3
nameOO 
:OO 
$strOO "
,OO" #
tablePP 
:PP 
$strPP '
,PP' (
typeQQ 
:QQ 
$strQQ !
,QQ! "
nullableRR 
:RR 
trueRR 
,RR 

oldClrTypeSS 
:SS 
typeofSS "
(SS" #
DateTimeSS# +
)SS+ ,
,SS, -
oldTypeTT 
:TT 
$strTT $
)TT$ %
;TT% &
migrationBuilderVV 
.VV 
AlterColumnVV (
<VV( )
stringVV) /
>VV/ 0
(VV0 1
nameWW 
:WW 
$strWW  
,WW  !
tableXX 
:XX 
$strXX '
,XX' (
typeYY 
:YY 
$strYY %
,YY% &
nullableZZ 
:ZZ 
trueZZ 
,ZZ 

oldClrType[[ 
:[[ 
typeof[[ "
([[" #
string[[# )
)[[) *
,[[* +
oldType\\ 
:\\ 
$str\\ (
)\\( )
;\\) *
migrationBuilder^^ 
.^^ 
AlterColumn^^ (
<^^( )
DateTime^^) 1
>^^1 2
(^^2 3
name__ 
:__ 
$str__ "
,__" #
table`` 
:`` 
$str`` '
,``' (
typeaa 
:aa 
$straa !
,aa! "
nullablebb 
:bb 
truebb 
,bb 

oldClrTypecc 
:cc 
typeofcc "
(cc" #
DateTimecc# +
)cc+ ,
,cc, -
oldTypedd 
:dd 
$strdd $
)dd$ %
;dd% &
migrationBuilderff 
.ff 
AlterColumnff (
<ff( )
stringff) /
>ff/ 0
(ff0 1
namegg 
:gg 
$strgg  
,gg  !
tablehh 
:hh 
$strhh '
,hh' (
typeii 
:ii 
$strii %
,ii% &
nullablejj 
:jj 
truejj 
,jj 

oldClrTypekk 
:kk 
typeofkk "
(kk" #
stringkk# )
)kk) *
,kk* +
oldTypell 
:ll 
$strll (
)ll( )
;ll) *
migrationBuildernn 
.nn 
AlterColumnnn (
<nn( )
DateTimenn) 1
>nn1 2
(nn2 3
nameoo 
:oo 
$stroo "
,oo" #
tablepp 
:pp 
$strpp #
,pp# $
typeqq 
:qq 
$strqq !
,qq! "
nullablerr 
:rr 
truerr 
,rr 

oldClrTypess 
:ss 
typeofss "
(ss" #
DateTimess# +
)ss+ ,
,ss, -
oldTypett 
:tt 
$strtt $
)tt$ %
;tt% &
migrationBuildervv 
.vv 
AlterColumnvv (
<vv( )
stringvv) /
>vv/ 0
(vv0 1
nameww 
:ww 
$strww  
,ww  !
tablexx 
:xx 
$strxx #
,xx# $
typeyy 
:yy 
$stryy %
,yy% &
nullablezz 
:zz 
truezz 
,zz 

oldClrType{{ 
:{{ 
typeof{{ "
({{" #
string{{# )
){{) *
,{{* +
oldType|| 
:|| 
$str|| (
)||( )
;||) *
migrationBuilder~~ 
.~~ 
AlterColumn~~ (
<~~( )
DateTime~~) 1
>~~1 2
(~~2 3
name 
: 
$str "
," #
table
�� 
:
�� 
$str
�� #
,
��# $
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
true
�� 
,
�� 

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� #
,
��# $
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
true
�� 
,
�� 

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
)
��( )
;
��) *
}
�� 	
	protected
�� 
override
�� 
void
�� 
Down
��  $
(
��$ %
MigrationBuilder
��% 5
migrationBuilder
��6 F
)
��F G
{
�� 	
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� *
,
��* +
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
DateTime
��" *
(
��* +
$num
��+ ,
,
��, -
$num
��. /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 5
,
��5 6
$num
��7 8
,
��8 9
$num
��: ;
,
��; <
$num
��= >
,
��> ?
DateTimeKind
��@ L
.
��L M
Unspecified
��M X
)
��X Y
,
��Y Z

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
,
��$ %
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� *
,
��* +
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� *
,
��* +
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
DateTime
��" *
(
��* +
$num
��+ ,
,
��, -
$num
��. /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 5
,
��5 6
$num
��7 8
,
��8 9
$num
��: ;
,
��; <
$num
��= >
,
��> ?
DateTimeKind
��@ L
.
��L M
Unspecified
��M X
)
��X Y
,
��Y Z

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
,
��$ %
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� *
,
��* +
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� +
,
��+ ,
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
DateTime
��" *
(
��* +
$num
��+ ,
,
��, -
$num
��. /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 5
,
��5 6
$num
��7 8
,
��8 9
$num
��: ;
,
��; <
$num
��= >
,
��> ?
DateTimeKind
��@ L
.
��L M
Unspecified
��M X
)
��X Y
,
��Y Z

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
,
��$ %
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� +
,
��+ ,
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� +
,
��+ ,
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
DateTime
��" *
(
��* +
$num
��+ ,
,
��, -
$num
��. /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 5
,
��5 6
$num
��7 8
,
��8 9
$num
��: ;
,
��; <
$num
��= >
,
��> ?
DateTimeKind
��@ L
.
��L M
Unspecified
��M X
)
��X Y
,
��Y Z

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
,
��$ %
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� +
,
��+ ,
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� '
,
��' (
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
DateTime
��" *
(
��* +
$num
��+ ,
,
��, -
$num
��. /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 5
,
��5 6
$num
��7 8
,
��8 9
$num
��: ;
,
��; <
$num
��= >
,
��> ?
DateTimeKind
��@ L
.
��L M
Unspecified
��M X
)
��X Y
,
��Y Z

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
,
��$ %
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� '
,
��' (
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� '
,
��' (
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
DateTime
��" *
(
��* +
$num
��+ ,
,
��, -
$num
��. /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 5
,
��5 6
$num
��7 8
,
��8 9
$num
��: ;
,
��; <
$num
��= >
,
��> ?
DateTimeKind
��@ L
.
��L M
Unspecified
��M X
)
��X Y
,
��Y Z

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
,
��$ %
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� '
,
��' (
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� #
,
��# $
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
DateTime
��" *
(
��* +
$num
��+ ,
,
��, -
$num
��. /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 5
,
��5 6
$num
��7 8
,
��8 9
$num
��: ;
,
��; <
$num
��= >
,
��> ?
DateTimeKind
��@ L
.
��L M
Unspecified
��M X
)
��X Y
,
��Y Z

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
,
��$ %
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� #
,
��# $
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� #
,
��# $
type
�� 
:
�� 
$str
�� !
,
��! "
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
new
�� !
DateTime
��" *
(
��* +
$num
��+ ,
,
��, -
$num
��. /
,
��/ 0
$num
��1 2
,
��2 3
$num
��4 5
,
��5 6
$num
��7 8
,
��8 9
$num
��: ;
,
��; <
$num
��= >
,
��> ?
DateTimeKind
��@ L
.
��L M
Unspecified
��M X
)
��X Y
,
��Y Z

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
DateTime
��# +
)
��+ ,
,
��, -
oldType
�� 
:
�� 
$str
�� $
,
��$ %
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
AlterColumn
�� (
<
��( )
string
��) /
>
��/ 0
(
��0 1
name
�� 
:
�� 
$str
��  
,
��  !
table
�� 
:
�� 
$str
�� #
,
��# $
type
�� 
:
�� 
$str
�� %
,
��% &
nullable
�� 
:
�� 
false
�� 
,
��  
defaultValue
�� 
:
�� 
$str
��  
,
��  !

oldClrType
�� 
:
�� 
typeof
�� "
(
��" #
string
��# )
)
��) *
,
��* +
oldType
�� 
:
�� 
$str
�� (
,
��( )
oldNullable
�� 
:
�� 
true
�� !
)
��! "
;
��" #
}
�� 	
}
�� 
}�� �$
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240620015801_AddCreateTimeInApplicationUser.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 *
AddCreateTimeInApplicationUser		 7
:		8 9
	Migration		: C
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str "
," #
table 
: 
$str $
,$ %
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
migrationBuilder 
. 

UpdateData '
(' (
table 
: 
$str $
,$ %
	keyColumn 
: 
$str 
,  
keyValue 
: 
$str +
,+ ,
columns 
: 
new 
[ 
] 
{  
$str! 3
,3 4
$str5 A
,A B
$strC Q
,Q R
$strS b
,b c
$strd p
}q r
,r s
values 
: 
new 
object "
[" #
]# $
{% &
$str' M
,M N
newO R
DateTimeS [
([ \
$num\ `
,` a
$numb c
,c d
$nume g
,g h
$numi j
,j k
$numl n
,n o
$nump r
,r s
$numt w
,w x
DateTimeKind	y �
.
� �
Utc
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
,
� �
$str
� �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Utc
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
}
� �
)
� �
;
� �
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name   
:   
$str   "
,  " #
table!! 
:!! 
$str!! $
)!!$ %
;!!% &
migrationBuilder## 
.## 

UpdateData## '
(##' (
table$$ 
:$$ 
$str$$ $
,$$$ %
	keyColumn%% 
:%% 
$str%% 
,%%  
keyValue&& 
:&& 
$str&& +
,&&+ ,
columns'' 
:'' 
new'' 
['' 
]'' 
{''  
$str''! 3
,''3 4
$str''5 C
,''C D
$str''E T
,''T U
$str''V b
}''c d
,''d e
values(( 
:(( 
new(( 
object(( "
[((" #
]((# $
{((% &
$str((' M
,((M N
$str	((O �
,
((� �
$str
((� �
,
((� �
new
((� �
DateTime
((� �
(
((� �
$num
((� �
,
((� �
$num
((� �
,
((� �
$num
((� �
,
((� �
$num
((� �
,
((� �
$num
((� �
,
((� �
$num
((� �
,
((� �
$num
((� �
,
((� �
DateTimeKind
((� �
.
((� �
Utc
((� �
)
((� �
.
((� �
AddTicks
((� �
(
((� �
$num
((� �
)
((� �
}
((� �
)
((� �
;
((� �
})) 	
}** 
}++ �*
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240619024532_AddMorePropertiesInstructor.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 '
AddMorePropertiesInstructor		 4
:		5 6
	Migration		7 @
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
bool' +
>+ ,
(, -
name 
: 
$str "
," #
table 
: 
$str $
,$ %
type 
: 
$str 
, 
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str "
," #
table 
: 
$str $
,$ %
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str $
,$ %
table 
: 
$str $
,$ %
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
migrationBuilder   
.   

UpdateData   '
(  ' (
table!! 
:!! 
$str!! $
,!!$ %
	keyColumn"" 
:"" 
$str"" 
,""  
keyValue## 
:## 
$str## +
,##+ ,
columns$$ 
:$$ 
new$$ 
[$$ 
]$$ 
{$$  
$str$$! 3
,$$3 4
$str$$5 C
,$$C D
$str$$E T
,$$T U
$str$$V b
}$$c d
,$$d e
values%% 
:%% 
new%% 
object%% "
[%%" #
]%%# $
{%%% &
$str%%' M
,%%M N
$str	%%O �
,
%%� �
$str
%%� �
,
%%� �
new
%%� �
DateTime
%%� �
(
%%� �
$num
%%� �
,
%%� �
$num
%%� �
,
%%� �
$num
%%� �
,
%%� �
$num
%%� �
,
%%� �
$num
%%� �
,
%%� �
$num
%%� �
,
%%� �
$num
%%� �
,
%%� �
DateTimeKind
%%� �
.
%%� �
Utc
%%� �
)
%%� �
.
%%� �
AddTicks
%%� �
(
%%� �
$num
%%� �
)
%%� �
}
%%� �
)
%%� �
;
%%� �
}&& 	
	protected)) 
override)) 
void)) 
Down))  $
())$ %
MigrationBuilder))% 5
migrationBuilder))6 F
)))F G
{** 	
migrationBuilder++ 
.++ 

DropColumn++ '
(++' (
name,, 
:,, 
$str,, "
,,," #
table-- 
:-- 
$str-- $
)--$ %
;--% &
migrationBuilder// 
.// 

DropColumn// '
(//' (
name00 
:00 
$str00 "
,00" #
table11 
:11 
$str11 $
)11$ %
;11% &
migrationBuilder33 
.33 

DropColumn33 '
(33' (
name44 
:44 
$str44 $
,44$ %
table55 
:55 
$str55 $
)55$ %
;55% &
migrationBuilder77 
.77 

UpdateData77 '
(77' (
table88 
:88 
$str88 $
,88$ %
	keyColumn99 
:99 
$str99 
,99  
keyValue:: 
::: 
$str:: +
,::+ ,
columns;; 
:;; 
new;; 
[;; 
];; 
{;;  
$str;;! 3
,;;3 4
$str;;5 C
,;;C D
$str;;E T
,;;T U
$str;;V b
};;c d
,;;d e
values<< 
:<< 
new<< 
object<< "
[<<" #
]<<# $
{<<% &
$str<<' M
,<<M N
$str	<<O �
,
<<� �
$str
<<� �
,
<<� �
new
<<� �
DateTime
<<� �
(
<<� �
$num
<<� �
,
<<� �
$num
<<� �
,
<<� �
$num
<<� �
,
<<� �
$num
<<� �
,
<<� �
$num
<<� �
,
<<� �
$num
<<� �
,
<<� �
$num
<<� �
,
<<� �
DateTimeKind
<<� �
.
<<� �
Utc
<<� �
)
<<� �
.
<<� �
AddTicks
<<� �
(
<<� �
$num
<<� �
)
<<� �
}
<<� �
)
<<� �
;
<<� �
}== 	
}>> 
}?? � 
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240619024142_RemoveIsAceptedInInstructor.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 '
RemoveIsAceptedInInstructor		 4
:		5 6
	Migration		7 @
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table 
: 
$str $
)$ %
;% &
migrationBuilder 
. 

UpdateData '
(' (
table 
: 
$str $
,$ %
	keyColumn 
: 
$str 
,  
keyValue 
: 
$str +
,+ ,
columns 
: 
new 
[ 
] 
{  
$str! 3
,3 4
$str5 C
,C D
$strE T
,T U
$strV b
}c d
,d e
values 
: 
new 
object "
[" #
]# $
{% &
$str' M
,M N
$str	O �
,
� �
$str
� �
,
� �
new
� �
DateTime
� �
(
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
$num
� �
,
� �
DateTimeKind
� �
.
� �
Utc
� �
)
� �
.
� �
AddTicks
� �
(
� �
$num
� �
)
� �
}
� �
)
� �
;
� �
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
bool' +
>+ ,
(, -
name 
: 
$str "
," #
table 
: 
$str $
,$ %
type   
:   
$str   
,   
nullable!! 
:!! 
false!! 
,!!  
defaultValue"" 
:"" 
false"" #
)""# $
;""$ %
migrationBuilder$$ 
.$$ 

UpdateData$$ '
($$' (
table%% 
:%% 
$str%% $
,%%$ %
	keyColumn&& 
:&& 
$str&& 
,&&  
keyValue'' 
:'' 
$str'' +
,''+ ,
columns(( 
:(( 
new(( 
[(( 
](( 
{((  
$str((! 3
,((3 4
$str((5 C
,((C D
$str((E T
,((T U
$str((V b
}((c d
,((d e
values)) 
:)) 
new)) 
object)) "
[))" #
]))# $
{))% &
$str))' M
,))M N
$str	))O �
,
))� �
$str
))� �
,
))� �
new
))� �
DateTime
))� �
(
))� �
$num
))� �
,
))� �
$num
))� �
,
))� �
$num
))� �
,
))� �
$num
))� �
,
))� �
$num
))� �
,
))� �
$num
))� �
,
))� �
$num
))� �
,
))� �
DateTimeKind
))� �
.
))� �
Utc
))� �
)
))� �
.
))� �
AddTicks
))� �
(
))� �
$num
))� �
)
))� �
}
))� �
)
))� �
;
))� �
}** 	
}++ 
},, �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240617111413_RemoveRejectedInInstructor.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 &
RemoveRejectedInInstructor		 3
:		4 5
	Migration		6 ?
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table 
: 
$str $
)$ %
;% &
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table 
: 
$str $
)$ %
;% &
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str $
,$ %
table 
: 
$str $
)$ %
;% &
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
bool' +
>+ ,
(, -
name 
: 
$str "
," #
table   
:   
$str   $
,  $ %
type!! 
:!! 
$str!! 
,!! 
nullable"" 
:"" 
false"" 
,""  
defaultValue## 
:## 
false## #
)### $
;##$ %
migrationBuilder%% 
.%% 
	AddColumn%% &
<%%& '
string%%' -
>%%- .
(%%. /
name&& 
:&& 
$str&& "
,&&" #
table'' 
:'' 
$str'' $
,''$ %
type(( 
:(( 
$str(( %
,((% &
nullable)) 
:)) 
false)) 
,))  
defaultValue** 
:** 
$str**  
)**  !
;**! "
migrationBuilder,, 
.,, 
	AddColumn,, &
<,,& '
DateTime,,' /
>,,/ 0
(,,0 1
name-- 
:-- 
$str-- $
,--$ %
table.. 
:.. 
$str.. $
,..$ %
type// 
:// 
$str// !
,//! "
nullable00 
:00 
true00 
)00 
;00  
}11 	
}22 
}33 �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614115054_AddEmailTemplatesSeedData.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public 

partial 
class %
AddEmailTemplatesSeedData 2
:3 4
	Migration5 >
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{   	
}"" 	
}## 
}$$ �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614074722_SeedAdminUserAndRoles.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{		 
public 

partial 
class !
SeedAdminUserAndRoles .
:/ 0
	Migration1 :
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
}## 	
	protected&& 
override&& 
void&& 
Down&&  $
(&&$ %
MigrationBuilder&&% 5
migrationBuilder&&6 F
)&&F G
{'' 	
}@@ 	
}AA 
}BB �8
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614063232_AddEmailTemplateTable.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 !
AddEmailTemplateTable		 .
:		/ 0
	Migration		1 :
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str &
,& '
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 D
,D E
nullableF N
:N O
falseP U
)U V
,V W
TemplateName  
=! "
table# (
.( )
Column) /
</ 0
string0 6
>6 7
(7 8
type8 <
:< =
$str> M
,M N
nullableO W
:W X
falseY ^
)^ _
,_ `

SenderName 
=  
table! &
.& '
Column' -
<- .
string. 4
>4 5
(5 6
type6 :
:: ;
$str< K
,K L
nullableM U
:U V
trueW [
)[ \
,\ ]
SenderEmail 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= L
,L M
nullableN V
:V W
trueX \
)\ ]
,] ^
Category 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \
SubjectLine 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= L
,L M
nullableN V
:V W
falseX ]
)] ^
,^ _
PreHeaderText !
=" #
table$ )
.) *
Column* 0
<0 1
string1 7
>7 8
(8 9
type9 =
:= >
$str? N
,N O
nullableP X
:X Y
trueZ ^
)^ _
,_ `
PersonalizationTags '
=( )
table* /
./ 0
Column0 6
<6 7
string7 =
>= >
(> ?
type? C
:C D
$strE T
,T U
nullableV ^
:^ _
true` d
)d e
,e f
BodyContent 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= L
,L M
nullableN V
:V W
falseX ]
)] ^
,^ _
FooterContent !
=" #
table$ )
.) *
Column* 0
<0 1
string1 7
>7 8
(8 9
type9 =
:= >
$str? N
,N O
nullableP X
:X Y
trueZ ^
)^ _
,_ `
CallToAction  
=! "
table# (
.( )
Column) /
</ 0
string0 6
>6 7
(7 8
type8 <
:< =
$str> M
,M N
nullableO W
:W X
trueY ]
)] ^
,^ _
Language 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
trueU Y
)Y Z
,Z [
RecipientType !
=" #
table$ )
.) *
Column* 0
<0 1
string1 7
>7 8
(8 9
type9 =
:= >
$str? N
,N O
nullableP X
:X Y
falseZ _
)_ `
,` a
CreateBy 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \

CreateTime   
=    
table  ! &
.  & '
Column  ' -
<  - .
DateTime  . 6
>  6 7
(  7 8
type  8 <
:  < =
$str  > I
,  I J
nullable  K S
:  S T
false  U Z
)  Z [
,  [ \
UpdateBy!! 
=!! 
table!! $
.!!$ %
Column!!% +
<!!+ ,
string!!, 2
>!!2 3
(!!3 4
type!!4 8
:!!8 9
$str!!: I
,!!I J
nullable!!K S
:!!S T
false!!U Z
)!!Z [
,!![ \

UpdateTime"" 
=""  
table""! &
.""& '
Column""' -
<""- .
DateTime"". 6
>""6 7
(""7 8
type""8 <
:""< =
$str""> I
,""I J
nullable""K S
:""S T
false""U Z
)""Z [
,""[ \
Status## 
=## 
table## "
.##" #
Column### )
<##) *
int##* -
>##- .
(##. /
type##/ 3
:##3 4
$str##5 :
,##: ;
nullable##< D
:##D E
false##F K
)##K L
}$$ 
,$$ 
constraints%% 
:%% 
table%% "
=>%%# %
{&& 
table'' 
.'' 

PrimaryKey'' $
(''$ %
$str''% 8
,''8 9
x'': ;
=>''< >
x''? @
.''@ A
Id''A C
)''C D
;''D E
}(( 
)(( 
;(( 
})) 	
	protected,, 
override,, 
void,, 
Down,,  $
(,,$ %
MigrationBuilder,,% 5
migrationBuilder,,6 F
),,F G
{-- 	
migrationBuilder.. 
... 
	DropTable.. &
(..& '
name// 
:// 
$str// &
)//& '
;//' (
}00 	
}11 
}22 �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614063134_AddStatusToBaseEntity.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public 

partial 
class !
AddStatusToBaseEntity .
:/ 0
	Migration1 :
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str 
, 
table 
: 
$str *
,* +
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$num 
)  
;  !
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str 
, 
table 
: 
$str +
,+ ,
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$num 
)  
;  !
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name   
:   
$str   
,   
table!! 
:!! 
$str!! *
)!!* +
;!!+ ,
migrationBuilder## 
.## 

DropColumn## '
(##' (
name$$ 
:$$ 
$str$$ 
,$$ 
table%% 
:%% 
$str%% +
)%%+ ,
;%%, -
}&& 	
}'' 
}(( �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614022706_AddRejectedByAndAcceptedByInTableInstructor.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public 

partial 
class 7
+AddRejectedByAndAcceptedByInTableInstructor D
:E F
	MigrationG P
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str "
," #
table 
: 
$str $
,$ %
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str "
," #
table 
: 
$str $
,$ %
type 
: 
$str %
,% &
nullable 
: 
false 
,  
defaultValue 
: 
$str  
)  !
;! "
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table   
:   
$str   $
)  $ %
;  % &
migrationBuilder"" 
."" 

DropColumn"" '
(""' (
name## 
:## 
$str## "
,##" #
table$$ 
:$$ 
$str$$ $
)$$$ %
;$$% &
}%% 	
}&& 
}'' �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614022444_AddMorePropertiesInTableInstructor.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 .
"AddMorePropertiesInTableInstructor		 ;
:		< =
	Migration		> G
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
RenameColumn )
() *
name 
: 
$str "
," #
table 
: 
$str $
,$ %
newName 
: 
$str %
)% &
;& '
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str $
,$ %
table 
: 
$str $
,$ %
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
bool' +
>+ ,
(, -
name 
: 
$str "
," #
table 
: 
$str $
,$ %
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
false #
)# $
;$ %
migrationBuilder   
.   
	AddColumn   &
<  & '
DateTime  ' /
>  / 0
(  0 1
name!! 
:!! 
$str!! $
,!!$ %
table"" 
:"" 
$str"" $
,""$ %
type## 
:## 
$str## !
,##! "
nullable$$ 
:$$ 
true$$ 
)$$ 
;$$  
}%% 	
	protected(( 
override(( 
void(( 
Down((  $
((($ %
MigrationBuilder((% 5
migrationBuilder((6 F
)((F G
{)) 	
migrationBuilder** 
.** 

DropColumn** '
(**' (
name++ 
:++ 
$str++ $
,++$ %
table,, 
:,, 
$str,, $
),,$ %
;,,% &
migrationBuilder.. 
... 

DropColumn.. '
(..' (
name// 
:// 
$str// "
,//" #
table00 
:00 
$str00 $
)00$ %
;00% &
migrationBuilder22 
.22 

DropColumn22 '
(22' (
name33 
:33 
$str33 $
,33$ %
table44 
:44 
$str44 $
)44$ %
;44% &
migrationBuilder66 
.66 
RenameColumn66 )
(66) *
name77 
:77 
$str77 "
,77" #
table88 
:88 
$str88 $
,88$ %
newName99 
:99 
$str99 %
)99% &
;99& '
}:: 	
};; 
}<< �$
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614021640_AddTableInstructorRating.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 $
AddTableInstructorRating		 1
:		2 3
	Migration		4 =
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str )
,) *
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 D
,D E
nullableF N
:N O
falseP U
)U V
,V W
InstructorId  
=! "
table# (
.( )
Column) /
</ 0
Guid0 4
>4 5
(5 6
type6 :
:: ;
$str< N
,N O
nullableP X
:X Y
falseZ _
)_ `
,` a
Rate 
= 
table  
.  !
Column! '
<' (
int( +
>+ ,
(, -
type- 1
:1 2
$str3 8
,8 9
nullable: B
:B C
falseD I
)I J
,J K
CreateBy 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \

CreateTime 
=  
table! &
.& '
Column' -
<- .
DateTime. 6
>6 7
(7 8
type8 <
:< =
$str> I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \
UpdateBy 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \

UpdateTime 
=  
table! &
.& '
Column' -
<- .
DateTime. 6
>6 7
(7 8
type8 <
:< =
$str> I
,I J
nullableK S
:S T
falseU Z
)Z [
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% ;
,; <
x= >
=>? A
xB C
.C D
IdD F
)F G
;G H
table 
. 

ForeignKey $
($ %
name 
: 
$str M
,M N
column 
: 
x  !
=>" $
x% &
.& '
InstructorId' 3
,3 4
principalTable   &
:  & '
$str  ( 5
,  5 6
principalColumn!! '
:!!' (
$str!!) 7
,!!7 8
onDelete""  
:""  !
ReferentialAction""" 3
.""3 4
Cascade""4 ;
)""; <
;""< =
}## 
)## 
;## 
migrationBuilder%% 
.%% 
CreateIndex%% (
(%%( )
name&& 
:&& 
$str&& 9
,&&9 :
table'' 
:'' 
$str'' *
,''* +
column(( 
:(( 
$str(( &
)((& '
;((' (
})) 	
	protected,, 
override,, 
void,, 
Down,,  $
(,,$ %
MigrationBuilder,,% 5
migrationBuilder,,6 F
),,F G
{-- 	
migrationBuilder.. 
... 
	DropTable.. &
(..& '
name// 
:// 
$str// )
)//) *
;//* +
}00 	
}11 
}22 �$
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614020848_AddTableInstructorComment.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 %
AddTableInstructorComment		 2
:		3 4
	Migration		5 >
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str *
,* +
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 D
,D E
nullableF N
:N O
falseP U
)U V
,V W
InstructorId  
=! "
table# (
.( )
Column) /
</ 0
Guid0 4
>4 5
(5 6
type6 :
:: ;
$str< N
,N O
nullableP X
:X Y
falseZ _
)_ `
,` a
Comment 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
CreateBy 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \

CreateTime 
=  
table! &
.& '
Column' -
<- .
DateTime. 6
>6 7
(7 8
type8 <
:< =
$str> I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \
UpdateBy 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \

UpdateTime 
=  
table! &
.& '
Column' -
<- .
DateTime. 6
>6 7
(7 8
type8 <
:< =
$str> I
,I J
nullableK S
:S T
falseU Z
)Z [
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% <
,< =
x> ?
=>@ B
xC D
.D E
IdE G
)G H
;H I
table 
. 

ForeignKey $
($ %
name 
: 
$str N
,N O
column 
: 
x  !
=>" $
x% &
.& '
InstructorId' 3
,3 4
principalTable   &
:  & '
$str  ( 5
,  5 6
principalColumn!! '
:!!' (
$str!!) 7
,!!7 8
onDelete""  
:""  !
ReferentialAction""" 3
.""3 4
Cascade""4 ;
)""; <
;""< =
}## 
)## 
;## 
migrationBuilder%% 
.%% 
CreateIndex%% (
(%%( )
name&& 
:&& 
$str&& :
,&&: ;
table'' 
:'' 
$str'' +
,''+ ,
column(( 
:(( 
$str(( &
)((& '
;((' (
})) 	
	protected,, 
override,, 
void,, 
Down,,  $
(,,$ %
MigrationBuilder,,% 5
migrationBuilder,,6 F
),,F G
{-- 	
migrationBuilder.. 
... 
	DropTable.. &
(..& '
name// 
:// 
$str// *
)//* +
;//+ ,
}00 	
}11 
}22 �<
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614013800_ModifyCategoryTable.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 
ModifyCategoryTable		 ,
:		- .
	Migration		/ 8
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str  
,  !
table 
: 
$str #
,# $
type 
: 
$str %
,% &
nullable 
: 
false 
,  
defaultValue 
: 
$str  
)  !
;! "
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str "
," #
table 
: 
$str #
,# $
type 
: 
$str !
,! "
nullable 
: 
false 
,  
defaultValue 
: 
new !
DateTime" *
(* +
$num+ ,
,, -
$num. /
,/ 0
$num1 2
,2 3
$num4 5
,5 6
$num7 8
,8 9
$num: ;
,; <
$num= >
,> ?
DateTimeKind@ L
.L M
UnspecifiedM X
)X Y
)Y Z
;Z [
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str #
,# $
table 
: 
$str #
,# $
type 
: 
$str %
,% &
nullable   
:   
true   
)   
;    
migrationBuilder"" 
."" 
	AddColumn"" &
<""& '
Guid""' +
>""+ ,
("", -
name## 
:## 
$str##  
,##  !
table$$ 
:$$ 
$str$$ #
,$$# $
type%% 
:%% 
$str%% (
,%%( )
nullable&& 
:&& 
true&& 
)&& 
;&&  
migrationBuilder(( 
.(( 
	AddColumn(( &
<((& '
int((' *
>((* +
(((+ ,
name)) 
:)) 
$str)) 
,)) 
table** 
:** 
$str** #
,**# $
type++ 
:++ 
$str++ 
,++ 
nullable,, 
:,, 
false,, 
,,,  
defaultValue-- 
:-- 
$num-- 
)--  
;--  !
migrationBuilder// 
.// 
	AddColumn// &
<//& '
string//' -
>//- .
(//. /
name00 
:00 
$str00  
,00  !
table11 
:11 
$str11 #
,11# $
type22 
:22 
$str22 %
,22% &
nullable33 
:33 
false33 
,33  
defaultValue44 
:44 
$str44  
)44  !
;44! "
migrationBuilder66 
.66 
	AddColumn66 &
<66& '
DateTime66' /
>66/ 0
(660 1
name77 
:77 
$str77 "
,77" #
table88 
:88 
$str88 #
,88# $
type99 
:99 
$str99 !
,99! "
nullable:: 
::: 
false:: 
,::  
defaultValue;; 
:;; 
new;; !
DateTime;;" *
(;;* +
$num;;+ ,
,;;, -
$num;;. /
,;;/ 0
$num;;1 2
,;;2 3
$num;;4 5
,;;5 6
$num;;7 8
,;;8 9
$num;;: ;
,;;; <
$num;;= >
,;;> ?
DateTimeKind;;@ L
.;;L M
Unspecified;;M X
);;X Y
);;Y Z
;;;Z [
migrationBuilder== 
.== 
CreateIndex== (
(==( )
name>> 
:>> 
$str>> .
,>>. /
table?? 
:?? 
$str?? #
,??# $
column@@ 
:@@ 
$str@@ "
)@@" #
;@@# $
migrationBuilderBB 
.BB 
AddForeignKeyBB *
(BB* +
nameCC 
:CC 
$strCC 9
,CC9 :
tableDD 
:DD 
$strDD #
,DD# $
columnEE 
:EE 
$strEE "
,EE" #
principalTableFF 
:FF 
$strFF  ,
,FF, -
principalColumnGG 
:GG  
$strGG! %
)GG% &
;GG& '
}HH 	
	protectedKK 
overrideKK 
voidKK 
DownKK  $
(KK$ %
MigrationBuilderKK% 5
migrationBuilderKK6 F
)KKF G
{LL 	
migrationBuilderMM 
.MM 
DropForeignKeyMM +
(MM+ ,
nameNN 
:NN 
$strNN 9
,NN9 :
tableOO 
:OO 
$strOO #
)OO# $
;OO$ %
migrationBuilderQQ 
.QQ 
	DropIndexQQ &
(QQ& '
nameRR 
:RR 
$strRR .
,RR. /
tableSS 
:SS 
$strSS #
)SS# $
;SS$ %
migrationBuilderUU 
.UU 

DropColumnUU '
(UU' (
nameVV 
:VV 
$strVV  
,VV  !
tableWW 
:WW 
$strWW #
)WW# $
;WW$ %
migrationBuilderYY 
.YY 

DropColumnYY '
(YY' (
nameZZ 
:ZZ 
$strZZ "
,ZZ" #
table[[ 
:[[ 
$str[[ #
)[[# $
;[[$ %
migrationBuilder]] 
.]] 

DropColumn]] '
(]]' (
name^^ 
:^^ 
$str^^ #
,^^# $
table__ 
:__ 
$str__ #
)__# $
;__$ %
migrationBuilderaa 
.aa 

DropColumnaa '
(aa' (
namebb 
:bb 
$strbb  
,bb  !
tablecc 
:cc 
$strcc #
)cc# $
;cc$ %
migrationBuilderee 
.ee 

DropColumnee '
(ee' (
nameff 
:ff 
$strff 
,ff 
tablegg 
:gg 
$strgg #
)gg# $
;gg$ %
migrationBuilderii 
.ii 

DropColumnii '
(ii' (
namejj 
:jj 
$strjj  
,jj  !
tablekk 
:kk 
$strkk #
)kk# $
;kk$ %
migrationBuildermm 
.mm 

DropColumnmm '
(mm' (
namenn 
:nn 
$strnn "
,nn" #
tableoo 
:oo 
$stroo #
)oo# $
;oo$ %
}pp 	
}qq 
}rr �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240608075025_AddUpdateTimeForApplicationUser.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 +
AddUpdateTimeForApplicationUser		 8
:		9 :
	Migration		; D
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str "
," #
table 
: 
$str $
,$ %
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table 
: 
$str $
)$ %
;% &
} 	
} 
} ؊
uD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240608073151_Initial.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  

Migrations  *
{ 
public		 

partial		 
class		 
Initial		  
:		! "
	Migration		# ,
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str #
,# $
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
string& ,
>, -
(- .
type. 2
:2 3
$str4 C
,C D
nullableE M
:M N
falseO T
)T U
,U V
Name 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 E
,E F
	maxLengthG P
:P Q
$numR U
,U V
nullableW _
:_ `
truea e
)e f
,f g
NormalizedName "
=# $
table% *
.* +
Column+ 1
<1 2
string2 8
>8 9
(9 :
type: >
:> ?
$str@ O
,O P
	maxLengthQ Z
:Z [
$num\ _
,_ `
nullablea i
:i j
truek o
)o p
,p q
ConcurrencyStamp $
=% &
table' ,
., -
Column- 3
<3 4
string4 :
>: ;
(; <
type< @
:@ A
$strB Q
,Q R
nullableS [
:[ \
true] a
)a b
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 5
,5 6
x7 8
=>9 ;
x< =
.= >
Id> @
)@ A
;A B
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str #
,# $
columns 
: 
table 
=> !
new" %
{ 
Id   
=   
table   
.   
Column   %
<  % &
string  & ,
>  , -
(  - .
type  . 2
:  2 3
$str  4 C
,  C D
nullable  E M
:  M N
false  O T
)  T U
,  U V
Gender!! 
=!! 
table!! "
.!!" #
Column!!# )
<!!) *
string!!* 0
>!!0 1
(!!1 2
type!!2 6
:!!6 7
$str!!8 G
,!!G H
nullable!!I Q
:!!Q R
true!!S W
)!!W X
,!!X Y
FullName"" 
="" 
table"" $
.""$ %
Column""% +
<""+ ,
string"", 2
>""2 3
(""3 4
type""4 8
:""8 9
$str"": I
,""I J
nullable""K S
:""S T
true""U Y
)""Y Z
,""Z [
	BirthDate## 
=## 
table##  %
.##% &
Column##& ,
<##, -
DateTime##- 5
>##5 6
(##6 7
type##7 ;
:##; <
$str##= H
,##H I
nullable##J R
:##R S
true##T X
)##X Y
,##Y Z
	AvatarUrl$$ 
=$$ 
table$$  %
.$$% &
Column$$& ,
<$$, -
string$$- 3
>$$3 4
($$4 5
type$$5 9
:$$9 :
$str$$; J
,$$J K
nullable$$L T
:$$T U
true$$V Z
)$$Z [
,$$[ \
Country%% 
=%% 
table%% #
.%%# $
Column%%$ *
<%%* +
string%%+ 1
>%%1 2
(%%2 3
type%%3 7
:%%7 8
$str%%9 H
,%%H I
nullable%%J R
:%%R S
true%%T X
)%%X Y
,%%Y Z
Address&& 
=&& 
table&& #
.&&# $
Column&&$ *
<&&* +
string&&+ 1
>&&1 2
(&&2 3
type&&3 7
:&&7 8
$str&&9 H
,&&H I
nullable&&J R
:&&R S
true&&T X
)&&X Y
,&&Y Z
	TaxNumber'' 
='' 
table''  %
.''% &
Column''& ,
<'', -
string''- 3
>''3 4
(''4 5
type''5 9
:''9 :
$str''; J
,''J K
nullable''L T
:''T U
true''V Z
)''Z [
,''[ \
UserName(( 
=(( 
table(( $
.(($ %
Column((% +
<((+ ,
string((, 2
>((2 3
(((3 4
type((4 8
:((8 9
$str((: I
,((I J
	maxLength((K T
:((T U
$num((V Y
,((Y Z
nullable(([ c
:((c d
true((e i
)((i j
,((j k
NormalizedUserName)) &
=))' (
table))) .
.)). /
Column))/ 5
<))5 6
string))6 <
>))< =
())= >
type))> B
:))B C
$str))D S
,))S T
	maxLength))U ^
:))^ _
$num))` c
,))c d
nullable))e m
:))m n
true))o s
)))s t
,))t u
Email** 
=** 
table** !
.**! "
Column**" (
<**( )
string**) /
>**/ 0
(**0 1
type**1 5
:**5 6
$str**7 F
,**F G
	maxLength**H Q
:**Q R
$num**S V
,**V W
nullable**X `
:**` a
true**b f
)**f g
,**g h
NormalizedEmail++ #
=++$ %
table++& +
.+++ ,
Column++, 2
<++2 3
string++3 9
>++9 :
(++: ;
type++; ?
:++? @
$str++A P
,++P Q
	maxLength++R [
:++[ \
$num++] `
,++` a
nullable++b j
:++j k
true++l p
)++p q
,++q r
EmailConfirmed,, "
=,,# $
table,,% *
.,,* +
Column,,+ 1
<,,1 2
bool,,2 6
>,,6 7
(,,7 8
type,,8 <
:,,< =
$str,,> C
,,,C D
nullable,,E M
:,,M N
false,,O T
),,T U
,,,U V
PasswordHash--  
=--! "
table--# (
.--( )
Column--) /
<--/ 0
string--0 6
>--6 7
(--7 8
type--8 <
:--< =
$str--> M
,--M N
nullable--O W
:--W X
true--Y ]
)--] ^
,--^ _
SecurityStamp.. !
=.." #
table..$ )
...) *
Column..* 0
<..0 1
string..1 7
>..7 8
(..8 9
type..9 =
:..= >
$str..? N
,..N O
nullable..P X
:..X Y
true..Z ^
)..^ _
,.._ `
ConcurrencyStamp// $
=//% &
table//' ,
.//, -
Column//- 3
<//3 4
string//4 :
>//: ;
(//; <
type//< @
://@ A
$str//B Q
,//Q R
nullable//S [
://[ \
true//] a
)//a b
,//b c
PhoneNumber00 
=00  !
table00" '
.00' (
Column00( .
<00. /
string00/ 5
>005 6
(006 7
type007 ;
:00; <
$str00= L
,00L M
nullable00N V
:00V W
true00X \
)00\ ]
,00] ^ 
PhoneNumberConfirmed11 (
=11) *
table11+ 0
.110 1
Column111 7
<117 8
bool118 <
>11< =
(11= >
type11> B
:11B C
$str11D I
,11I J
nullable11K S
:11S T
false11U Z
)11Z [
,11[ \
TwoFactorEnabled22 $
=22% &
table22' ,
.22, -
Column22- 3
<223 4
bool224 8
>228 9
(229 :
type22: >
:22> ?
$str22@ E
,22E F
nullable22G O
:22O P
false22Q V
)22V W
,22W X

LockoutEnd33 
=33  
table33! &
.33& '
Column33' -
<33- .
DateTimeOffset33. <
>33< =
(33= >
type33> B
:33B C
$str33D T
,33T U
nullable33V ^
:33^ _
true33` d
)33d e
,33e f
LockoutEnabled44 "
=44# $
table44% *
.44* +
Column44+ 1
<441 2
bool442 6
>446 7
(447 8
type448 <
:44< =
$str44> C
,44C D
nullable44E M
:44M N
false44O T
)44T U
,44U V
AccessFailedCount55 %
=55& '
table55( -
.55- .
Column55. 4
<554 5
int555 8
>558 9
(559 :
type55: >
:55> ?
$str55@ E
,55E F
nullable55G O
:55O P
false55Q V
)55V W
}66 
,66 
constraints77 
:77 
table77 "
=>77# %
{88 
table99 
.99 

PrimaryKey99 $
(99$ %
$str99% 5
,995 6
x997 8
=>999 ;
x99< =
.99= >
Id99> @
)99@ A
;99A B
}:: 
):: 
;:: 
migrationBuilder<< 
.<< 
CreateTable<< (
(<<( )
name== 
:== 
$str== "
,==" #
columns>> 
:>> 
table>> 
=>>> !
new>>" %
{?? 
Id@@ 
=@@ 
table@@ 
.@@ 
Column@@ %
<@@% &
Guid@@& *
>@@* +
(@@+ ,
type@@, 0
:@@0 1
$str@@2 D
,@@D E
nullable@@F N
:@@N O
false@@P U
)@@U V
,@@V W
NameAA 
=AA 
tableAA  
.AA  !
ColumnAA! '
<AA' (
stringAA( .
>AA. /
(AA/ 0
typeAA0 4
:AA4 5
$strAA6 E
,AAE F
nullableAAG O
:AAO P
falseAAQ V
)AAV W
}BB 
,BB 
constraintsCC 
:CC 
tableCC "
=>CC# %
{DD 
tableEE 
.EE 

PrimaryKeyEE $
(EE$ %
$strEE% 4
,EE4 5
xEE6 7
=>EE8 :
xEE; <
.EE< =
IdEE= ?
)EE? @
;EE@ A
}FF 
)FF 
;FF 
migrationBuilderHH 
.HH 
CreateTableHH (
(HH( )
nameII 
:II 
$strII 
,II 
columnsJJ 
:JJ 
tableJJ 
=>JJ !
newJJ" %
{KK 
IdLL 
=LL 
tableLL 
.LL 
ColumnLL %
<LL% &
GuidLL& *
>LL* +
(LL+ ,
typeLL, 0
:LL0 1
$strLL2 D
,LLD E
nullableLLF N
:LLN O
falseLLP U
)LLU V
,LLV W
NameMM 
=MM 
tableMM  
.MM  !
ColumnMM! '
<MM' (
stringMM( .
>MM. /
(MM/ 0
typeMM0 4
:MM4 5
$strMM6 E
,MME F
nullableMMG O
:MMO P
falseMMQ V
)MMV W
}NN 
,NN 
constraintsOO 
:OO 
tableOO "
=>OO# %
{PP 
tableQQ 
.QQ 

PrimaryKeyQQ $
(QQ$ %
$strQQ% 0
,QQ0 1
xQQ2 3
=>QQ4 6
xQQ7 8
.QQ8 9
IdQQ9 ;
)QQ; <
;QQ< =
}RR 
)RR 
;RR 
migrationBuilderTT 
.TT 
CreateTableTT (
(TT( )
nameUU 
:UU 
$strUU (
,UU( )
columnsVV 
:VV 
tableVV 
=>VV !
newVV" %
{WW 
IdXX 
=XX 
tableXX 
.XX 
ColumnXX %
<XX% &
intXX& )
>XX) *
(XX* +
typeXX+ /
:XX/ 0
$strXX1 6
,XX6 7
nullableXX8 @
:XX@ A
falseXXB G
)XXG H
.YY 

AnnotationYY #
(YY# $
$strYY$ 8
,YY8 9
$strYY: @
)YY@ A
,YYA B
RoleIdZZ 
=ZZ 
tableZZ "
.ZZ" #
ColumnZZ# )
<ZZ) *
stringZZ* 0
>ZZ0 1
(ZZ1 2
typeZZ2 6
:ZZ6 7
$strZZ8 G
,ZZG H
nullableZZI Q
:ZZQ R
falseZZS X
)ZZX Y
,ZZY Z
	ClaimType[[ 
=[[ 
table[[  %
.[[% &
Column[[& ,
<[[, -
string[[- 3
>[[3 4
([[4 5
type[[5 9
:[[9 :
$str[[; J
,[[J K
nullable[[L T
:[[T U
true[[V Z
)[[Z [
,[[[ \

ClaimValue\\ 
=\\  
table\\! &
.\\& '
Column\\' -
<\\- .
string\\. 4
>\\4 5
(\\5 6
type\\6 :
:\\: ;
$str\\< K
,\\K L
nullable\\M U
:\\U V
true\\W [
)\\[ \
}]] 
,]] 
constraints^^ 
:^^ 
table^^ "
=>^^# %
{__ 
table`` 
.`` 

PrimaryKey`` $
(``$ %
$str``% :
,``: ;
x``< =
=>``> @
x``A B
.``B C
Id``C E
)``E F
;``F G
tableaa 
.aa 

ForeignKeyaa $
(aa$ %
namebb 
:bb 
$strbb F
,bbF G
columncc 
:cc 
xcc  !
=>cc" $
xcc% &
.cc& '
RoleIdcc' -
,cc- .
principalTabledd &
:dd& '
$strdd( 5
,dd5 6
principalColumnee '
:ee' (
$stree) -
,ee- .
onDeleteff  
:ff  !
ReferentialActionff" 3
.ff3 4
Cascadeff4 ;
)ff; <
;ff< =
}gg 
)gg 
;gg 
migrationBuilderii 
.ii 
CreateTableii (
(ii( )
namejj 
:jj 
$strjj (
,jj( )
columnskk 
:kk 
tablekk 
=>kk !
newkk" %
{ll 
Idmm 
=mm 
tablemm 
.mm 
Columnmm %
<mm% &
intmm& )
>mm) *
(mm* +
typemm+ /
:mm/ 0
$strmm1 6
,mm6 7
nullablemm8 @
:mm@ A
falsemmB G
)mmG H
.nn 

Annotationnn #
(nn# $
$strnn$ 8
,nn8 9
$strnn: @
)nn@ A
,nnA B
UserIdoo 
=oo 
tableoo "
.oo" #
Columnoo# )
<oo) *
stringoo* 0
>oo0 1
(oo1 2
typeoo2 6
:oo6 7
$stroo8 G
,ooG H
nullableooI Q
:ooQ R
falseooS X
)ooX Y
,ooY Z
	ClaimTypepp 
=pp 
tablepp  %
.pp% &
Columnpp& ,
<pp, -
stringpp- 3
>pp3 4
(pp4 5
typepp5 9
:pp9 :
$strpp; J
,ppJ K
nullableppL T
:ppT U
trueppV Z
)ppZ [
,pp[ \

ClaimValueqq 
=qq  
tableqq! &
.qq& '
Columnqq' -
<qq- .
stringqq. 4
>qq4 5
(qq5 6
typeqq6 :
:qq: ;
$strqq< K
,qqK L
nullableqqM U
:qqU V
trueqqW [
)qq[ \
}rr 
,rr 
constraintsss 
:ss 
tabless "
=>ss# %
{tt 
tableuu 
.uu 

PrimaryKeyuu $
(uu$ %
$struu% :
,uu: ;
xuu< =
=>uu> @
xuuA B
.uuB C
IduuC E
)uuE F
;uuF G
tablevv 
.vv 

ForeignKeyvv $
(vv$ %
nameww 
:ww 
$strww F
,wwF G
columnxx 
:xx 
xxx  !
=>xx" $
xxx% &
.xx& '
UserIdxx' -
,xx- .
principalTableyy &
:yy& '
$stryy( 5
,yy5 6
principalColumnzz '
:zz' (
$strzz) -
,zz- .
onDelete{{  
:{{  !
ReferentialAction{{" 3
.{{3 4
Cascade{{4 ;
){{; <
;{{< =
}|| 
)|| 
;|| 
migrationBuilder~~ 
.~~ 
CreateTable~~ (
(~~( )
name 
: 
$str (
,( )
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
LoginProvider
�� !
=
��" #
table
��$ )
.
��) *
Column
��* 0
<
��0 1
string
��1 7
>
��7 8
(
��8 9
type
��9 =
:
��= >
$str
��? N
,
��N O
nullable
��P X
:
��X Y
false
��Z _
)
��_ `
,
��` a
ProviderKey
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
string
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= L
,
��L M
nullable
��N V
:
��V W
false
��X ]
)
��] ^
,
��^ _!
ProviderDisplayName
�� '
=
��( )
table
��* /
.
��/ 0
Column
��0 6
<
��6 7
string
��7 =
>
��= >
(
��> ?
type
��? C
:
��C D
$str
��E T
,
��T U
nullable
��V ^
:
��^ _
true
��` d
)
��d e
,
��e f
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% :
,
��: ;
x
��< =
=>
��> @
new
��A D
{
��E F
x
��G H
.
��H I
LoginProvider
��I V
,
��V W
x
��X Y
.
��Y Z
ProviderKey
��Z e
}
��f g
)
��g h
;
��h i
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� F
,
��F G
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� '
,
��' (
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
RoleId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 9
,
��9 :
x
��; <
=>
��= ?
new
��@ C
{
��D E
x
��F G
.
��G H
UserId
��H N
,
��N O
x
��P Q
.
��Q R
RoleId
��R X
}
��Y Z
)
��Z [
;
��[ \
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� E
,
��E F
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
RoleId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� E
,
��E F
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� (
,
��( )
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
LoginProvider
�� !
=
��" #
table
��$ )
.
��) *
Column
��* 0
<
��0 1
string
��1 7
>
��7 8
(
��8 9
type
��9 =
:
��= >
$str
��? N
,
��N O
nullable
��P X
:
��X Y
false
��Z _
)
��_ `
,
��` a
Name
�� 
=
�� 
table
��  
.
��  !
Column
��! '
<
��' (
string
��( .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 E
,
��E F
nullable
��G O
:
��O P
false
��Q V
)
��V W
,
��W X
Value
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
string
��) /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 F
,
��F G
nullable
��H P
:
��P Q
true
��R V
)
��V W
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% :
,
��: ;
x
��< =
=>
��> @
new
��A D
{
��E F
x
��G H
.
��H I
UserId
��I O
,
��O P
x
��Q R
.
��R S
LoginProvider
��S `
,
��` a
x
��b c
.
��c d
Name
��d h
}
��i j
)
��j k
;
��k l
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� F
,
��F G
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� #
,
��# $
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
InstructorId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< N
,
��N O
nullable
��P X
:
��X Y
false
��Z _
)
��_ `
,
��` a
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
Degree
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
DegreeImageUrl
�� "
=
��# $
table
��% *
.
��* +
Column
��+ 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ O
,
��O P
nullable
��Q Y
:
��Y Z
true
��[ _
)
��_ `
,
��` a
Industry
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
string
��, 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
,
��[ \
Introduction
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
string
��0 6
>
��6 7
(
��7 8
type
��8 <
:
��< =
$str
��> M
,
��M N
nullable
��O W
:
��W X
false
��Y ^
)
��^ _
,
��_ `

isAccepted
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
bool
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 5
,
��5 6
x
��7 8
=>
��9 ;
x
��< =
.
��= >
InstructorId
��> J
)
��J K
;
��K L
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� A
,
��A B
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� $
,
��$ %
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 

CardNumber
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
string
��. 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
CardName
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
string
��, 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
,
��[ \
CardProvider
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
string
��0 6
>
��6 7
(
��7 8
type
��8 <
:
��< =
$str
��> M
,
��M N
nullable
��O W
:
��W X
false
��Y ^
)
��^ _
,
��_ `
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 6
,
��6 7
x
��8 9
=>
��: <
x
��= >
.
��> ?

CardNumber
��? I
)
��I J
;
��J K
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
��  
,
��  !
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
	StudentId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
UserId
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
string
��* 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z

University
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
string
��. 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 2
,
��2 3
x
��4 5
=>
��6 8
x
��9 :
.
��: ;
	StudentId
��; D
)
��D E
;
��E F
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� >
,
��> ?
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
UserId
��' -
,
��- .
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� 
,
��  
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
InstructorId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< N
,
��N O
nullable
��P X
:
��X Y
false
��Z _
)
��_ `
,
��` a

CategoryId
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
Guid
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: L
,
��L M
nullable
��N V
:
��V W
false
��X ]
)
��] ^
,
��^ _
LevelId
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
Guid
��+ /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
,
��[ \
CreateAt
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
DateTime
��, 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
StudentSlot
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
int
��/ 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
LearningTime
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTime
��0 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
Price
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
double
��) /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q
CourseImgUrl
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
string
��0 6
>
��6 7
(
��7 8
type
��8 <
:
��< =
$str
��> M
,
��M N
nullable
��O W
:
��W X
true
��Y ]
)
��] ^
,
��^ _
Title
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
string
��) /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
Description
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
string
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= L
,
��L M
nullable
��N V
:
��V W
false
��X ]
)
��] ^
,
��^ _

IsAccepted
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
bool
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
,
��Q R
IsDelete
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
bool
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 =
,
��= >
nullable
��? G
:
��G H
false
��I N
)
��N O
,
��O P
	TotalRate
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
float
��- 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: @
,
��@ A
nullable
��B J
:
��J K
false
��L Q
)
��Q R
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 1
,
��1 2
x
��3 4
=>
��5 7
x
��8 9
.
��9 :
Id
��: <
)
��< =
;
��= >
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� @
,
��@ A
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '

CategoryId
��' 1
,
��1 2
principalTable
�� &
:
��& '
$str
��( 4
,
��4 5
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� C
,
��C D
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
InstructorId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) 7
,
��7 8
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� 9
,
��9 :
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
LevelId
��' .
,
��. /
principalTable
�� &
:
��& '
$str
��( 0
,
��0 1
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� #
,
��# $
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
	StudentId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^

TotalPrice
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
double
��. 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< C
,
��C D
nullable
��E M
:
��M N
false
��O T
)
��T U
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 5
,
��5 6
x
��7 8
=>
��9 ;
x
��< =
.
��= >
Id
��> @
)
��@ A
;
��A B
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� A
,
��A B
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
	StudentId
��' 0
,
��0 1
principalTable
�� &
:
��& '
$str
��( 2
,
��2 3
principalColumn
�� '
:
��' (
$str
��) 4
,
��4 5
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� $
,
��$ %
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
	StudentId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
CreateAt
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
DateTime
��, 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z

OrderPrice
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
double
��. 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< C
,
��C D
nullable
��E M
:
��M N
false
��O T
)
��T U
,
��U V
IsPayout
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
bool
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 =
,
��= >
nullable
��? G
:
��G H
false
��I N
)
��N O
,
��O P
	IsSuccess
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 6
,
��6 7
x
��8 9
=>
��: <
x
��= >
.
��> ?
Id
��? A
)
��A B
;
��B C
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
	StudentId
��' 0
,
��0 1
principalTable
�� &
:
��& '
$str
��( 2
,
��2 3
principalColumn
�� '
:
��' (
$str
��) 4
,
��4 5
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
	StudentId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
CourseId
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
Guid
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 J
,
��J K
nullable
��L T
:
��T U
false
��V [
)
��[ \
,
��\ ]
CreateAt
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
DateTime
��, 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
Message
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
string
��+ 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 H
,
��H I
nullable
��J R
:
��R S
false
��T Y
)
��Y Z
,
��Z [
IsSent
�� 
=
�� 
table
�� "
.
��" #
Column
��# )
<
��) *
bool
��* .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 ;
,
��; <
nullable
��= E
:
��E F
false
��G L
)
��L M
,
��M N

IsAccepted
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
bool
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 7
,
��7 8
x
��9 :
=>
��; =
x
��> ?
.
��? @
Id
��@ B
)
��B C
;
��C D
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� A
,
��A B
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
CourseId
��' /
,
��/ 0
principalTable
�� &
:
��& '
$str
��( 1
,
��1 2
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
	StudentId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
CourseId
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
Guid
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 J
,
��J K
nullable
��L T
:
��T U
false
��V [
)
��[ \
,
��\ ]
Rate
�� 
=
�� 
table
��  
.
��  !
Column
��! '
<
��' (
float
��( -
>
��- .
(
��. /
type
��/ 3
:
��3 4
$str
��5 ;
,
��; <
nullable
��= E
:
��E F
false
��G L
)
��L M
,
��M N
Message
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
string
��+ 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 H
,
��H I
nullable
��J R
:
��R S
false
��T Y
)
��Y Z
,
��Z [
CreateAt
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
DateTime
��, 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< G
,
��G H
nullable
��I Q
:
��Q R
false
��S X
)
��X Y
,
��Y Z
IsDelete
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
bool
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 =
,
��= >
nullable
��? G
:
��G H
false
��I N
)
��N O
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 7
,
��7 8
x
��9 :
=>
��; =
x
��> ?
.
��? @
Id
��@ B
)
��B C
;
��C D
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� A
,
��A B
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
CourseId
��' /
,
��/ 0
principalTable
�� &
:
��& '
$str
��( 1
,
��1 2
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� &
,
��& '
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
CourseId
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
Guid
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 J
,
��J K
nullable
��L T
:
��T U
false
��V [
)
��[ \
,
��\ ]
Title
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
string
��) /
>
��/ 0
(
��0 1
type
��1 5
:
��5 6
$str
��7 F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
Description
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
string
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= L
,
��L M
nullable
��N V
:
��V W
false
��X ]
)
��] ^
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 8
,
��8 9
x
��: ;
=>
��< >
x
��? @
.
��@ A
Id
��A C
)
��C D
;
��D E
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
CourseId
��' /
,
��/ 0
principalTable
�� &
:
��& '
$str
��( 1
,
��1 2
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� &
,
��& '
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
	StudentId
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
Guid
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 K
,
��K L
nullable
��M U
:
��U V
true
��W [
)
��[ \
,
��\ ]
CourseId
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
Guid
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 J
,
��J K
nullable
��L T
:
��T U
true
��V Z
)
��Z [
,
��[ \
LearningTime
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
DateTime
��0 8
>
��8 9
(
��9 :
type
��: >
:
��> ?
$str
��@ K
,
��K L
nullable
��M U
:
��U V
false
��W \
)
��\ ]
,
��] ^
StartAt
�� 
=
�� 
table
�� #
.
��# $
Column
��$ *
<
��* +
DateTime
��+ 3
>
��3 4
(
��4 5
type
��5 9
:
��9 :
$str
��; F
,
��F G
nullable
��H P
:
��P Q
false
��R W
)
��W X
,
��X Y
EndAt
�� 
=
�� 
table
�� !
.
��! "
Column
��" (
<
��( )
DateTime
��) 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
CertificateImgUrl
�� %
=
��& '
table
��( -
.
��- .
Column
��. 4
<
��4 5
string
��5 ;
>
��; <
(
��< =
type
��= A
:
��A B
$str
��C R
,
��R S
nullable
��T \
:
��\ ]
false
��^ c
)
��c d
,
��d e
	IsSuccess
�� 
=
�� 
table
��  %
.
��% &
Column
��& ,
<
��, -
bool
��- 1
>
��1 2
(
��2 3
type
��3 7
:
��7 8
$str
��9 >
,
��> ?
nullable
��@ H
:
��H I
false
��J O
)
��O P
,
��P Q

IsExpelled
�� 
=
��  
table
��! &
.
��& '
Column
��' -
<
��- .
bool
��. 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: ?
,
��? @
nullable
��A I
:
��I J
false
��K P
)
��P Q
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 8
,
��8 9
x
��: ;
=>
��< >
x
��? @
.
��@ A
Id
��A C
)
��C D
;
��D E
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� B
,
��B C
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
CourseId
��' /
,
��/ 0
principalTable
�� &
:
��& '
$str
��( 1
,
��1 2
principalColumn
�� '
:
��' (
$str
��) -
)
��- .
;
��. /
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� D
,
��D E
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
	StudentId
��' 0
,
��0 1
principalTable
�� &
:
��& '
$str
��( 2
,
��2 3
principalColumn
�� '
:
��' (
$str
��) 4
)
��4 5
;
��5 6
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� #
,
��# $
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
CartHeaderId
��  
=
��! "
table
��# (
.
��( )
Column
��) /
<
��/ 0
Guid
��0 4
>
��4 5
(
��5 6
type
��6 :
:
��: ;
$str
��< N
,
��N O
nullable
��P X
:
��X Y
false
��Z _
)
��_ `
,
��` a
CourseId
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
Guid
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 J
,
��J K
nullable
��L T
:
��T U
false
��V [
)
��[ \
,
��\ ]
CoursePrice
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
double
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 5
,
��5 6
x
��7 8
=>
��9 ;
x
��< =
.
��= >
Id
��> @
)
��@ A
;
��A B
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� G
,
��G H
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
CartHeaderId
��' 3
,
��3 4
principalTable
�� &
:
��& '
$str
��( 5
,
��5 6
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� $
,
��$ %
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
CourseId
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
Guid
��, 0
>
��0 1
(
��1 2
type
��2 6
:
��6 7
$str
��8 J
,
��J K
nullable
��L T
:
��T U
false
��V [
)
��[ \
,
��\ ]
CoursePrice
�� 
=
��  !
table
��" '
.
��' (
Column
��( .
<
��. /
double
��/ 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
OrderHeaderId
�� !
=
��" #
table
��$ )
.
��) *
Column
��* 0
<
��0 1
Guid
��1 5
>
��5 6
(
��6 7
type
��7 ;
:
��; <
$str
��= O
,
��O P
nullable
��Q Y
:
��Y Z
false
��[ `
)
��` a
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 6
,
��6 7
x
��8 9
=>
��: <
x
��= >
.
��> ?
Id
��? A
)
��A B
;
��B C
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� J
,
��J K
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
OrderHeaderId
��' 4
,
��4 5
principalTable
�� &
:
��& '
$str
��( 6
,
��6 7
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateTable
�� (
(
��( )
name
�� 
:
�� 
$str
�� &
,
��& '
columns
�� 
:
�� 
table
�� 
=>
�� !
new
��" %
{
�� 
Id
�� 
=
�� 
table
�� 
.
�� 
Column
�� %
<
��% &
Guid
��& *
>
��* +
(
��+ ,
type
��, 0
:
��0 1
$str
��2 D
,
��D E
nullable
��F N
:
��N O
false
��P U
)
��U V
,
��V W
CourseSectionId
�� #
=
��$ %
table
��& +
.
��+ ,
Column
��, 2
<
��2 3
Guid
��3 7
>
��7 8
(
��8 9
type
��9 =
:
��= >
$str
��? Q
,
��Q R
nullable
��S [
:
��[ \
false
��] b
)
��b c
,
��c d
Name
�� 
=
�� 
table
��  
.
��  !
Column
��! '
<
��' (
string
��( .
>
��. /
(
��/ 0
type
��0 4
:
��4 5
$str
��6 E
,
��E F
nullable
��G O
:
��O P
false
��Q V
)
��V W
,
��W X
VideoUrl
�� 
=
�� 
table
�� $
.
��$ %
Column
��% +
<
��+ ,
string
��, 2
>
��2 3
(
��3 4
type
��4 8
:
��8 9
$str
��: I
,
��I J
nullable
��K S
:
��S T
false
��U Z
)
��Z [
}
�� 
,
�� 
constraints
�� 
:
�� 
table
�� "
=>
��# %
{
�� 
table
�� 
.
�� 

PrimaryKey
�� $
(
��$ %
$str
��% 8
,
��8 9
x
��: ;
=>
��< >
x
��? @
.
��@ A
Id
��A C
)
��C D
;
��D E
table
�� 
.
�� 

ForeignKey
�� $
(
��$ %
name
�� 
:
�� 
$str
�� P
,
��P Q
column
�� 
:
�� 
x
��  !
=>
��" $
x
��% &
.
��& '
CourseSectionId
��' 6
,
��6 7
principalTable
�� &
:
��& '
$str
��( 8
,
��8 9
principalColumn
�� '
:
��' (
$str
��) -
,
��- .
onDelete
��  
:
��  !
ReferentialAction
��" 3
.
��3 4
Cascade
��4 ;
)
��; <
;
��< =
}
�� 
)
�� 
;
�� 
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� )
,
��) *
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� (
,
��( )
unique
�� 
:
�� 
true
�� 
,
�� 
filter
�� 
:
�� 
$str
�� 6
)
��6 7
;
��7 8
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� )
,
��) *
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� )
,
��) *
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
�� (
,
��( )
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� "
,
��" #
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� )
)
��) *
;
��* +
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� %
,
��% &
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� ,
,
��, -
unique
�� 
:
�� 
true
�� 
,
�� 
filter
�� 
:
�� 
$str
�� :
)
��: ;
;
��; <
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 3
,
��3 4
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� &
)
��& '
;
��' (
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 0
,
��0 1
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
�� &
,
��& '
column
�� 
:
�� 
$str
�� "
)
��" #
;
��# $
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
�� &
,
��& '
column
�� 
:
�� 
$str
�� "
)
��" #
;
��# $
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� -
,
��- .
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� /
,
��/ 0
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� &
)
��& '
;
��' (
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� *
,
��* +
table
�� 
:
�� 
$str
��  
,
��  !
column
�� 
:
�� 
$str
�� !
)
��! "
;
��" #
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� '
,
��' (
column
�� 
:
�� 
$str
�� "
)
��" #
;
��# $
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� -
,
��- .
table
�� 
:
�� 
$str
�� $
,
��$ %
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 5
,
��5 6
table
�� 
:
�� 
$str
�� %
,
��% &
column
�� 
:
�� 
$str
�� '
)
��' (
;
��( )
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 1
,
��1 2
table
�� 
:
�� 
$str
�� %
,
��% &
column
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� .
,
��. /
table
�� 
:
�� 
$str
�� %
,
��% &
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 9
,
��9 :
table
�� 
:
�� 
$str
�� '
,
��' (
column
�� 
:
�� 
$str
�� )
)
��) *
;
��* +
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 2
,
��2 3
table
�� 
:
�� 
$str
�� '
,
��' (
column
�� 
:
�� 
$str
�� "
)
��" #
;
��# $
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� 3
,
��3 4
table
�� 
:
�� 
$str
�� '
,
��' (
column
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
CreateIndex
�� (
(
��( )
name
�� 
:
�� 
$str
�� *
,
��* +
table
�� 
:
�� 
$str
�� !
,
��! "
column
�� 
:
�� 
$str
��  
)
��  !
;
��! "
}
�� 	
	protected
�� 
override
�� 
void
�� 
Down
��  $
(
��$ %
MigrationBuilder
��% 5
migrationBuilder
��6 F
)
��F G
{
�� 	
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� (
)
��( )
;
��) *
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� (
)
��( )
;
��) *
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� (
)
��( )
;
��) *
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� '
)
��' (
;
��( )
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� (
)
��( )
;
��) *
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� %
)
��% &
;
��& '
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� %
)
��% &
;
��& '
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� &
)
��& '
;
��' (
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� &
)
��& '
;
��' (
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� $
)
��$ %
;
��% &
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� &
)
��& '
;
��' (
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
��  
)
��  !
;
��! "
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� 
)
��  
;
��  !
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� "
)
��" #
;
��# $
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� 
)
�� 
;
��  
migrationBuilder
�� 
.
�� 
	DropTable
�� &
(
��& '
name
�� 
:
�� 
$str
�� #
)
��# $
;
��$ %
}
�� 	
}
�� 
}�� �
vD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IUserManagerRepository.cs
	namespace		 	
Cursus		
 
.		 
LMS		 
.		 

DataAccess		 
.		  
IRepository		  +
{

 
public 

	interface "
IUserManagerRepository +
{ 
Task 
< 
ApplicationUser 
> 
FindByEmailAsync .
(. /
string/ 5
email6 ;
); <
;< =
Task 
< 
bool 
> )
CheckIfPhoneNumberExistsAsync 0
(0 1
string1 7
phoneNumber8 C
)C D
;D E
Task 
< 
IdentityResult 
> 
CreateAsync (
(( )
ApplicationUser) 8
user9 =
,= >
string? E
passwordF N
)N O
;O P
Task 
< 
IdentityResult 
> 
AddToRoleAsync +
(+ ,
ApplicationUser, ;
user< @
,@ A
stringB H
roleI M
)M N
;N O
Task 
< 
ApplicationUser 
> 
FindByIdAsync +
(+ ,
string, 2
userId3 9
)9 :
;: ;
Task 
< 
ApplicationUser 
> 
FindByPhoneAsync .
(. /
string/ 5
phoneNumber6 A
)A B
;B C
Task 
< 
List 
< 
ApplicationUser !
>! "
>" #
GetInstructorUser$ 5
(5 6
)6 7
;7 8
Task 
< 
List 
< 
ApplicationUser !
>! "
>" #
GetStudentUser$ 2
(2 3
)3 4
;4 5
Task 
< 
IEnumerable 
< 
ApplicationUser (
>( )
>) *
GetUsersInRoleAsync+ >
(> ?
string? E
roleF J
)J K
;K L
} 
} �
kD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IUnitOfWork.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface 
IUnitOfWork 
{ 
IStudentRepository 
StudentRepository (
{) *
get+ .
;. /
}0 1!
IInstructorRepository  
InstructorRepository .
{/ 0
get1 4
;4 5
}6 7
ICategoryRepository		 
CategoryRepository		 *
{		+ ,
get		- 0
;		0 1
}		2 3$
IEmailTemplateRepository

 #
EmailTemplateRepository

 4
{

5 6
get

7 :
;

: ;
}

< ="
IUserManagerRepository !
UserManagerRepository 0
{1 2
get3 6
;6 7
}8 9(
IInstructorCommentRepository  '
InstructorCommentRepository! <
{= >
get? B
;B C
}D E
ICourseRepository 
CourseRepository &
{' (
get) ,
;, -
}. /"
IPaymentCardRepository !
PaymentCardRepository 0
{1 2
get3 6
;6 7
}8 9'
IInstructorRatingRepository &
InstructorRatingRepository  :
{; <
get= @
;@ A
}B C$
ICourseVersionRepository #
CourseVersionRepository 4
{5 6
get7 :
;: ;
}< =+
ICourseSectionVersionRepository #*
CourseSectionVersionRepository$ B
{C D
getE H
;H I
}J K,
 ISectionDetailsVersionRepository $+
SectionDetailsVersionRepository% D
{E F
getG J
;J K
}L M*
ICourseVersionStatusRepository ")
CourseVersionStatusRepository# @
{A B
getC F
;F G
}H I+
ICourseVersionCommentRepository #*
CourseVersionCommentRepository$ B
{C D
getE H
;H I
}J K$
IStudentCourseRepository #
StudentCourseRepository 4
{5 6
get7 :
;: ;
}< =
ILevelRepository 
LevelRepository $
{% &
get' *
;* +
}, -
Task 
< 	
int	 
> 
	SaveAsync 
( 
) 
; 
} �
rD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IStudentRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface 
IStudentRepository #
:$ %
IRepository& 1
<1 2
Student2 9
>9 :
{ 
void 
Update	 
( 
Student 
student 
)  
;  !
void 
UpdateRange	 
( 
IEnumerable  
<  !
Student! (
>( )
students* 2
)2 3
;3 4
Task		 
<		 	
Student			 
>		 
AddAsync		 
(		 
Student		 "
student		# *
)		* +
;		+ ,
}

 �
xD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IStudentCourseRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface $
IStudentCourseRepository )
:* +
IRepository, 7
<7 8
StudentCourse8 E
>E F
{ 
void 
Update	 
( 
StudentCourse 
studentCourse +
)+ ,
;, -
void 
UpdateRange	 
( 
IEnumerable  
<  !
StudentCourse! .
>. /
studentCourses0 >
)> ?
;? @
}		 �
�D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ISectionDetailsVersionRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface ,
 ISectionDetailsVersionRepository 1
:2 3
IRepository4 ?
<? @!
SectionDetailsVersion@ U
>U V
{ 
void 
Update	 
( !
SectionDetailsVersion %!
sectionDetailsVersion& ;
); <
;< =
void 
UpdateRange	 
( 
IEnumerable  
<  !!
SectionDetailsVersion! 6
>6 7"
sectionDetailsVersions8 N
)N O
;O P
Task

 
<

 	
List

	 
<

 !
SectionDetailsVersion

 #
>

# $
?

$ %
>

% &@
4GetSectionDetailsVersionsOfCourseSectionVersionAsync

' [
( 
Guid "
courseSectionVersionId #
,# $
bool 
? 
asNoTracking 
) 
; 
Task 
< 	!
SectionDetailsVersion	 
? 
>  (
GetSectionDetailsVersionById! =
(= >
Guid> B
	detailsIdC L
)L M
;M N
} �
kD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface 
IRepository 
< 
T 
> 
where  %
T& '
:( )
class* /
{ 
Task 
< 	
IEnumerable	 
< 
T 
> 
> 
GetAllAsync $
($ %

Expression% /
</ 0
Func0 4
<4 5
T5 6
,6 7
bool8 <
>< =
>= >
?> ?
filter@ F
=G H
nullI M
,M N
stringO U
?U V
includePropertiesW h
=i j
nullk o
)o p
;p q
Task 
< 	
T	 

?
 
> 
GetAsync 
( 

Expression  
<  !
Func! %
<% &
T& '
,' (
bool) -
>- .
>. /
filter0 6
,6 7
string8 >
?> ?
includeProperties@ Q
=R S
nullT X
)X Y
;Y Z
Task		 
AddAsync			 
(		 
T		 
entity		 
)		 
;		 
Task

 
AddRangeAsync

	 
(

 
IEnumerable

 "
<

" #
T

# $
>

$ %
entities

& .
)

. /
;

/ 0
void 
Remove	 
( 
T 
entity 
) 
; 
void 
RemoveRange	 
( 
IEnumerable  
<  !
T! "
>" #
entities$ ,
), -
;- .
} �
vD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IPaymentCardRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface "
IPaymentCardRepository '
:( )
IRepository* 5
<5 6
PaymentCard6 A
>A B
{ 
void 
Update	 
( 
PaymentCard 
paymentCard '
)' (
;( )
void 
UpdateRange	 
( 
IEnumerable  
<  !
PaymentCard! ,
>, -
paymentCards. :
): ;
;; <
Task		 
<		 	
PaymentCard			 
?		 
>		 !
CardNumberExistsAsync		 ,
(		, -
string		- 3

cardNumber		4 >
)		> ?
;		? @
Task

 
<

 	
PaymentCard

	 
?

 
>

 
GetCardByUserId

 &
(

& '
string

' -
id

. 0
)

0 1
;

1 2
Task 
< 	
PaymentCard	 
> 
AddAsync 
( 
PaymentCard *
paymentCard+ 6
)6 7
;7 8
} �
pD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ILevelRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface 
ILevelRepository !
:" #
IRepository$ /
</ 0
Level0 5
>5 6
{ 
void 
Update	 
( 
Level 
level 
) 
; 
void 
UpdateRange	 
( 
IEnumerable  
<  !
Level! &
>& '
levels( .
). /
;/ 0
Task		 
<		 	
Level			 
>		 
GetLevelById		 
(		 
Guid		 !
levelId		" )
)		) *
;		* +
}

 �	
uD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IInstructorRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface !
IInstructorRepository &
:' (
IRepository) 4
<4 5

Instructor5 ?
>? @
{ 
void 
Update	 
( 

Instructor 

instructor %
)% &
;& '
void		 
UpdateRange			 
(		 
IEnumerable		  
<		  !

Instructor		! +
>		+ ,
instructors		- 8
)		8 9
;		9 :
Task

 
<

 	

Instructor

	 
?

 
>

 
GetById

 
(

 
Guid

 "
id

# %
)

% &
;

& '
Task 
< 	!
IDbContextTransaction	 
> !
BeginTransactionAsync  5
(5 6
)6 7
;7 8
} �
{D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IInstructorRatingRepository.cs
public 
	interface '
IInstructorRatingRepository ,
:- .
IRepository/ :
<: ;
InstructorRating; K
>K L
{ 
void 
Update	 
( 
InstructorRating  
instructorRating! 1
)1 2
;2 3
void 
UpdateRange	 
( 
IEnumerable  
<  !
InstructorRating! 1
>1 2
instructorRatings3 D
)D E
;E F
} �
|D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IInstructorCommentRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface (
IInstructorCommentRepository -
:. /
IRepository0 ;
<; <
InstructorComment< M
>M N
{ 
void 
Update	 
( 
InstructorComment !
instructorComment" 3
)3 4
;4 5
void 
UpdateRange	 
( 
IEnumerable  
<  !
InstructorComment! 2
>2 3
instructorComments4 F
)F G
;G H
}		 �
xD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\IEmailTemplateRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface $
IEmailTemplateRepository )
:* +
IRepository, 7
<7 8
EmailTemplate8 E
>E F
{ 
void 
Update	 
( 
EmailTemplate 
emailTemplate +
)+ ,
;, -
} �
~D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ICourseVersionStatusRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface *
ICourseVersionStatusRepository /
:0 1
IRepository2 =
<= >
CourseVersionStatus> Q
>Q R
{ 
void 
Update	 
( 
CourseVersionStatus #
courseVersionStatus$ 7
)7 8
;8 9
void 
UpdateRange	 
( 
IEnumerable  
<  !
CourseVersionStatus! 4
>4 5 
courseVersionsStatus6 J
)J K
;K L
Task		 
<		 	
CourseVersionStatus			 
?		 
>		 +
GetCourseVersionStatusByIdAsync		 >
(		> ?
Guid		? C!
courseVersionStatusId		D Y
)		Y Z
;		Z [
}

 �

xD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ICourseVersionRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface $
ICourseVersionRepository )
:* +
IRepository, 7
<7 8
CourseVersion8 E
>E F
{ 
void 
Update	 
( 
CourseVersion 
courseVersion +
)+ ,
;, -
void 
UpdateRange	 
( 
IEnumerable  
<  !
CourseVersion! .
>. /
courseVersions0 >
)> ?
;? @
Task		 
<		 	
CourseVersion			 
?		 
>		 !
GetCourseVersionAsync		 .
(		. /
Guid		/ 3
courseVersionId		4 C
,		C D
bool		E I
?		I J
asNoTracking		K W
)		W X
;		X Y
Task

 
<

 	
int

	 
>

 '
GetTotalCourseVersionsAsync

 )
(

) *
Guid

* .
?

. /
courseId

0 8
)

8 9
;

9 :
} �
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ICourseVersionCommentRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface +
ICourseVersionCommentRepository 0
:1 2
IRepository3 >
<> ? 
CourseVersionComment? S
>S T
{ 
void 
Update	 
(  
CourseVersionComment $ 
courseVersionComment% 9
)9 :
;: ;
void 
UpdateRange	 
( 
IEnumerable  
<  ! 
CourseVersionComment! 5
>5 6!
courseVersionComments7 L
)L M
;M N
Task		 
<		 	 
CourseVersionComment			 
?		 
>		 '
GetCourseVersionCommentById		  ;
(		; <
Guid		< @"
courseversioncommentId		A W
)		W X
;		X Y
}

 �	
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ICourseSectionVersionRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface +
ICourseSectionVersionRepository 0
:1 2
IRepository3 >
<> ? 
CourseSectionVersion? S
>S T
{ 
void 
Update	 
(  
CourseSectionVersion $ 
courseSectionVersion% 9
)9 :
;: ;
void 
UpdateRange	 
( 
IEnumerable  
<  ! 
CourseSectionVersion! 5
>5 6!
courseSectionVersions7 L
)L M
;M N
Task		 
<		 	
List			 
<		  
CourseSectionVersion		 "
>		" #
?		# $
>		$ %8
,GetCourseSectionVersionsOfCourseVersionAsync		& R
(		R S
Guid		S W
courseVersionId		X g
,		g h
bool		i m
?		m n
asNoTracking		o {
)		{ |
;		| }
}

 �
qD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ICourseRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
{		 
public

 

	interface

 
ICourseRepository

 &
:

' (
IRepository

) 4
<

4 5
Course

5 ;
>

; <
{ 
void 
Update 
( 
Course 
course !
)! "
;" #
void 
UpdateRange 
( 
IEnumerable $
<$ %
Course% +
>+ ,
courses- 4
)4 5
;5 6
} 
} �
sD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ICategoryRepository.cs
	namespace 	
Cursus
 
. 
LMS 
. 

DataAccess 
.  
IRepository  +
;+ ,
public 
	interface 
ICategoryRepository $
:$ %
IRepository& 1
<1 2
Category2 :
>: ;
{ 
void 
Update	 
( 
Category 
category !
)! "
;" #
void 
UpdateRange	 
( 
IEnumerable  
<  !
Category! )
>) *

categories+ 5
)5 6
;6 7
Task		 
<		 	
Category			 
>		  
GetCategoryByIdAsync		 '
(		' (
Guid		( ,
id		- /
)		/ 0
;		0 1
}

 �0
pD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Context\ApplicationDbContext.cs
	namespace		 	
Cursus		
 
.		 
LMS		 
.		 

DataAccess		 
.		  
Context		  '
;		' (
public 
class  
ApplicationDbContext !
:" #
IdentityDbContext$ 5
<5 6
ApplicationUser6 E
>E F
{ 
public 
 
ApplicationDbContext 
(  
DbContextOptions  0
<0 1 
ApplicationDbContext1 E
>E F
optionsG N
)N O
:P Q
baseR V
(V W
optionsW ^
)^ _
{ 
} 
	protected 
override 
void 
OnModelCreating +
(+ ,
ModelBuilder, 8
modelBuilder9 E
)E F
{ 
base 
. 
OnModelCreating 
( 
modelBuilder )
)) *
;* +$
ApplicationDbContextSeed  
.  !
SeedAdminAccount! 1
(1 2
modelBuilder2 >
)> ?
;? @$
ApplicationDbContextSeed  
.  !
SeedEmailTemplate! 2
(2 3
modelBuilder3 ?
)? @
;@ A
} 
public 

DbSet 
< 
ApplicationUser  
>  !
ApplicationUsers" 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 

DbSet 
< 
CartDetails 
> 
CartDetails )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 

DbSet 
< 

CartHeader 
> 
CartHeaders (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 

DbSet 
< 
Category 
> 

Categories %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 

DbSet 
< 
Course 
> 
Courses  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 

DbSet 
< 
CourseReport 
> 
CourseReports ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 

DbSet 
< 
CourseReview 
> 
CourseReviews ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public   

DbSet   
<   

Instructor   
>   
Instructors   (
{  ) *
get  + .
;  . /
set  0 3
;  3 4
}  5 6
public!! 

DbSet!! 
<!! 
Level!! 
>!! 
Levels!! 
{!!  
get!!! $
;!!$ %
set!!& )
;!!) *
}!!+ ,
public"" 

DbSet"" 
<"" 
OrderDetails"" 
>"" 
OrderDetails"" +
{"", -
get"". 1
;""1 2
set""3 6
;""6 7
}""8 9
public## 

DbSet## 
<## 
OrderHeader## 
>## 
OrderHeaders## *
{##+ ,
get##- 0
;##0 1
set##2 5
;##5 6
}##7 8
public$$ 

DbSet$$ 
<$$ 
Student$$ 
>$$ 
Students$$ "
{$$# $
get$$% (
;$$( )
set$$* -
;$$- .
}$$/ 0
public%% 

DbSet%% 
<%% 
StudentCourse%% 
>%% 
StudentCourses%%  .
{%%/ 0
get%%1 4
;%%4 5
set%%6 9
;%%9 :
}%%; <
public&& 

DbSet&& 
<&& 
PaymentCard&& 
>&& 
PaymentCards&& *
{&&+ ,
get&&- 0
;&&0 1
set&&2 5
;&&5 6
}&&7 8
public'' 

DbSet'' 
<'' 
InstructorComment'' "
>''" #
InstructorComments''$ 6
{''7 8
get''9 <
;''< =
set''> A
;''A B
}''C D
public(( 

DbSet(( 
<(( 
InstructorRating(( !
>((! "
InstructorRatings((# 4
{((5 6
get((7 :
;((: ;
set((< ?
;((? @
}((A B
public)) 

DbSet)) 
<)) 
EmailTemplate)) 
>)) 
EmailTemplates))  .
{))/ 0
get))1 4
;))4 5
set))6 9
;))9 :
})); <
public** 

DbSet** 
<** 
CourseVersion** 
>** 
CourseVersions**  .
{**/ 0
get**1 4
;**4 5
set**6 9
;**9 :
}**; <
public++ 

DbSet++ 
<++  
CourseSectionVersion++ %
>++% &!
CourseSectionVersions++' <
{++= >
get++? B
;++B C
set++D G
;++G H
}++I J
public,, 

DbSet,, 
<,, !
SectionDetailsVersion,, &
>,,& '"
SectionDetailsVersions,,( >
{,,? @
get,,A D
;,,D E
set,,F I
;,,I J
},,K L
public-- 

DbSet-- 
<-- 
CourseVersionStatus-- $
>--$ %
CourseVersionStatus--& 9
{--: ;
get--< ?
;--? @
set--A D
;--D E
}--F G
public.. 

DbSet.. 
<..  
CourseVersionComment.. %
>..% &!
CourseVersionComments..' <
{..= >
get..? B
;..B C
set..D G
;..G H
}..I J
}// 