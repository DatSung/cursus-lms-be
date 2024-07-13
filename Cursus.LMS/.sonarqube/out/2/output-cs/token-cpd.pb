õ¨
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
$str	22 Š
,
22Š ‹
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
$str	`` º
"
``º »
,
``» ¼
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
€€ 
Id
 
=
 
Guid
 
.
 
NewGuid
 !
(
! "
)
" #
,
# $
TemplateName
‚‚ 
=
‚‚ 
$str
‚‚ 4
,
‚‚4 5

SenderName
ƒƒ 
=
ƒƒ 
$str
ƒƒ )
,
ƒƒ) *
SenderEmail
„„ 
=
„„ 
$str
„„ 4
,
„„4 5
Category
…… 
=
…… 
$str
…… )
,
……) *
SubjectLine
†† 
=
†† 
$str
†† /
,
††/ 0
PreHeaderText
‡‡ 
=
‡‡ 
$str
‡‡  0
,
‡‡0 1!
PersonalizationTags
ˆˆ #
=
ˆˆ$ %
$str
ˆˆ& 2
,
ˆˆ2 3
BodyContent
‰‰ 
=
‰‰ 
$str
‰‰ e
,
‰‰e f
FooterContent
ŠŠ 
=
ŠŠ 
$str
ŠŠ  Q
,
ŠŠQ R
CallToAction
‹‹ 
=
‹‹ 
$str
‹‹ H
,
‹‹H I
Language
ŒŒ 
=
ŒŒ 
$str
ŒŒ $
,
ŒŒ$ %
RecipientType
 
=
 
$str
  *
,
* +
CreateBy
 
=
 
$str
 #
,
# $

CreateTime
 
=
 
DateTime
 %
.
% &
Now
& )
,
) *
UpdateBy
 
=
 
$str
 "
,
" #

UpdateTime
‘‘ 
=
‘‘ 
DateTime
‘‘ %
.
‘‘% &
Now
‘‘& )
,
‘‘) *
Status
’’ 
=
’’ 
$num
’’ 
}
““ 
,
““ 
new
”” 
{
•• 
Id
–– 
=
–– 
Guid
–– 
.
–– 
NewGuid
–– !
(
––! "
)
––" #
,
––# $
TemplateName
—— 
=
—— 
$str
—— C
,
——C D

SenderName
˜˜ 
=
˜˜ 
$str
˜˜ *
,
˜˜* +
SenderEmail
™™ 
=
™™ 
$str
™™ :
,
™™: ;
Category
šš 
=
šš 
$str
šš -
,
šš- .
SubjectLine
›› 
=
›› 
$str
›› <
,
››< =
PreHeaderText
œœ 
=
œœ 
$str
œœ  >
,
œœ> ?!
PersonalizationTags
 #
=
$ %
$str
& ?
,
? @
BodyContent
 
=
 
$str
 g
,
g h
FooterContent
ŸŸ 
=
ŸŸ 
$str
ŸŸ  Q
,
ŸŸQ R
CallToAction
   
=
   
$str
   O
,
  O P
Language
¡¡ 
=
¡¡ 
$str
¡¡ $
,
¡¡$ %
RecipientType
¢¢ 
=
¢¢ 
$str
¢¢  '
,
¢¢' (
CreateBy
££ 
=
££ 
$str
££ #
,
££# $

CreateTime
¤¤ 
=
¤¤ 
DateTime
¤¤ %
.
¤¤% &
Now
¤¤& )
,
¤¤) *
UpdateBy
¥¥ 
=
¥¥ 
$str
¥¥ "
,
¥¥" #

UpdateTime
¦¦ 
=
¦¦ 
DateTime
¦¦ %
.
¦¦% &
Now
¦¦& )
,
¦¦) *
Status
§§ 
=
§§ 
$num
§§ 
}
¨¨ 
,
¨¨ 
new
©© 
{
ªª 
Id
«« 
=
«« 
Guid
«« 
.
«« 
NewGuid
«« !
(
««! "
)
««" #
,
««# $
TemplateName
¬¬ 
=
¬¬ 
$str
¬¬ 8
,
¬¬8 9

SenderName
­­ 
=
­­ 
$str
­­ *
,
­­* +
SenderEmail
®® 
=
®® 
$str
®® :
,
®®: ;
Category
¯¯ 
=
¯¯ 
$str
¯¯ 2
,
¯¯2 3
SubjectLine
°° 
=
°° 
$str
°° >
,
°°> ?
PreHeaderText
±± 
=
±± 
$str
±±  B
,
±±B C!
PersonalizationTags
²² #
=
²²$ %
$str
²²& ?
,
²²? @
BodyContent
³³ 
=
³³ 
$str
³³ e
,
³³e f
FooterContent
´´ 
=
´´ 
$str
´´  Q
,
´´Q R
CallToAction
µµ 
=
µµ 
$str
µµ O
,
µµO P
Language
¶¶ 
=
¶¶ 
$str
¶¶ $
,
¶¶$ %
RecipientType
·· 
=
·· 
$str
··  ,
,
··, -
CreateBy
¸¸ 
=
¸¸ 
$str
¸¸ #
,
¸¸# $

CreateTime
¹¹ 
=
¹¹ 
DateTime
¹¹ %
.
¹¹% &
Now
¹¹& )
,
¹¹) *
UpdateBy
ºº 
=
ºº 
$str
ºº "
,
ºº" #

UpdateTime
»» 
=
»» 
DateTime
»» %
.
»»% &
Now
»»& )
,
»») *
Status
¼¼ 
=
¼¼ 
$num
¼¼ 
}
½½ 
,
½½ 
new
¾¾ 
{
¿¿ 
Id
ÀÀ 
=
ÀÀ 
Guid
ÀÀ 
.
ÀÀ 
NewGuid
ÀÀ !
(
ÀÀ! "
)
ÀÀ" #
,
ÀÀ# $
TemplateName
ÁÁ 
=
ÁÁ 
$str
ÁÁ 7
,
ÁÁ7 8

SenderName
ÂÂ 
=
ÂÂ 
$str
ÂÂ *
,
ÂÂ* +
SenderEmail
ÃÃ 
=
ÃÃ 
$str
ÃÃ :
,
ÃÃ: ;
Category
ÄÄ 
=
ÄÄ 
$str
ÄÄ 2
,
ÄÄ2 3
SubjectLine
ÅÅ 
=
ÅÅ 
$str
ÅÅ >
,
ÅÅ> ?
PreHeaderText
ÆÆ 
=
ÆÆ 
$str
ÆÆ  F
,
ÆÆF G!
PersonalizationTags
ÇÇ #
=
ÇÇ$ %
$str
ÇÇ& ?
,
ÇÇ? @
BodyContent
ÈÈ 
=
ÈÈ 
$str
ÈÈ e
,
ÈÈe f
FooterContent
ÉÉ 
=
ÉÉ 
$str
ÉÉ  Q
,
ÉÉQ R
CallToAction
ÊÊ 
=
ÊÊ 
$str
ÊÊ O
,
ÊÊO P
Language
ËË 
=
ËË 
$str
ËË $
,
ËË$ %
RecipientType
ÌÌ 
=
ÌÌ 
$str
ÌÌ  ,
,
ÌÌ, -
CreateBy
ÍÍ 
=
ÍÍ 
$str
ÍÍ #
,
ÍÍ# $

CreateTime
ÎÎ 
=
ÎÎ 
DateTime
ÎÎ %
.
ÎÎ% &
Now
ÎÎ& )
,
ÎÎ) *
UpdateBy
ÏÏ 
=
ÏÏ 
$str
ÏÏ "
,
ÏÏ" #

UpdateTime
ĞĞ 
=
ĞĞ 
DateTime
ĞĞ %
.
ĞĞ% &
Now
ĞĞ& )
,
ĞĞ) *
Status
ÑÑ 
=
ÑÑ 
$num
ÑÑ 
}
ÒÒ 
)
ÓÓ 	
;
ÓÓ	 

}
ÔÔ 
public
ÚÚ 

static
ÚÚ 
void
ÚÚ 
SeedAdminAccount
ÚÚ '
(
ÚÚ' (
ModelBuilder
ÚÚ( 4
modelBuilder
ÚÚ5 A
)
ÚÚA B
{
ÛÛ 
var
ÜÜ 
studentRoleId
ÜÜ 
=
ÜÜ 
$str
ÜÜ B
;
ÜÜB C
var
İİ 
instructorRoleId
İİ 
=
İİ 
$str
İİ E
;
İİE F
var
ŞŞ 
adminRoleId
ŞŞ 
=
ŞŞ 
$str
ŞŞ @
;
ŞŞ@ A
var
àà 
roles
àà 
=
àà 
new
àà 
List
àà 
<
àà 
IdentityRole
àà )
>
àà) *
{
áá 	
new
ââ 
IdentityRole
ââ 
{
ãã 
Id
ää 
=
ää 
studentRoleId
ää "
,
ää" #
ConcurrencyStamp
åå  
=
åå! "
StaticUserRoles
åå# 2
.
åå2 3
Student
åå3 :
,
åå: ;
Name
ææ 
=
ææ 
StaticUserRoles
ææ &
.
ææ& '
Student
ææ' .
,
ææ. /
NormalizedName
çç 
=
çç  
StaticUserRoles
çç! 0
.
çç0 1
Student
çç1 8
,
çç8 9
}
èè 
,
èè 
new
éé 
IdentityRole
éé 
{
êê 
Id
ëë 
=
ëë 
instructorRoleId
ëë %
,
ëë% &
ConcurrencyStamp
ìì  
=
ìì! "
StaticUserRoles
ìì# 2
.
ìì2 3

Instructor
ìì3 =
,
ìì= >
Name
íí 
=
íí 
StaticUserRoles
íí &
.
íí& '

Instructor
íí' 1
,
íí1 2
NormalizedName
îî 
=
îî  
StaticUserRoles
îî! 0
.
îî0 1

Instructor
îî1 ;
,
îî; <
}
ïï 
,
ïï 
new
ğğ 
IdentityRole
ğğ 
{
ññ 
Id
òò 
=
òò 
adminRoleId
òò  
,
òò  !
ConcurrencyStamp
óó  
=
óó! "
StaticUserRoles
óó# 2
.
óó2 3
Admin
óó3 8
,
óó8 9
Name
ôô 
=
ôô 
StaticUserRoles
ôô &
.
ôô& '
Admin
ôô' ,
,
ôô, -
NormalizedName
õõ 
=
õõ  
StaticUserRoles
õõ! 0
.
õõ0 1
Admin
õõ1 6
,
õõ6 7
}
öö 
}
÷÷ 	
;
÷÷	 

modelBuilder
ùù 
.
ùù 
Entity
ùù 
<
ùù 
IdentityRole
ùù (
>
ùù( )
(
ùù) *
)
ùù* +
.
ùù+ ,
HasData
ùù, 3
(
ùù3 4
roles
ùù4 9
)
ùù9 :
;
ùù: ;
var
üü 
adminUserId
üü 
=
üü 
$str
üü +
;
üü+ ,
var
ıı 
hasher
ıı 
=
ıı 
new
ıı 
PasswordHasher
ıı '
<
ıı' (
ApplicationUser
ıı( 7
>
ıı7 8
(
ıı8 9
)
ıı9 :
;
ıı: ;
var
şş 
	adminUser
şş 
=
şş 
new
şş 
ApplicationUser
şş +
{
ÿÿ 	
Id
€€ 
=
€€ 
adminUserId
€€ 
,
€€ 
Gender
 
=
 
$str
 
,
 
FullName
‚‚ 
=
‚‚ 
$str
‚‚ #
,
‚‚# $
	BirthDate
ƒƒ 
=
ƒƒ 
new
ƒƒ 
DateTime
ƒƒ $
(
ƒƒ$ %
$num
ƒƒ% )
,
ƒƒ) *
$num
ƒƒ+ ,
,
ƒƒ, -
$num
ƒƒ. /
)
ƒƒ/ 0
,
ƒƒ0 1
	AvatarUrl
„„ 
=
„„ 
$str
„„ 8
,
„„8 9
Country
…… 
=
…… 
$str
…… 
,
……  
Address
†† 
=
†† 
$str
†† $
,
††$ %
	TaxNumber
‡‡ 
=
‡‡ 
$str
‡‡ #
,
‡‡# $
UserName
ˆˆ 
=
ˆˆ 
$str
ˆˆ (
,
ˆˆ( ) 
NormalizedUserName
‰‰ 
=
‰‰  
$str
‰‰! 2
,
‰‰2 3
Email
ŠŠ 
=
ŠŠ 
$str
ŠŠ %
,
ŠŠ% &
NormalizedEmail
‹‹ 
=
‹‹ 
$str
‹‹ /
,
‹‹/ 0
EmailConfirmed
ŒŒ 
=
ŒŒ 
true
ŒŒ !
,
ŒŒ! "
PasswordHash
 
=
 
hasher
 !
.
! "
HashPassword
" .
(
. /
null
/ 3
,
3 4
$str
5 @
)
@ A
,
A B
SecurityStamp
 
=
 
Guid
  
.
  !
NewGuid
! (
(
( )
)
) *
.
* +
ToString
+ 3
(
3 4
)
4 5
,
5 6
ConcurrencyStamp
 
=
 
Guid
 #
.
# $
NewGuid
$ +
(
+ ,
)
, -
.
- .
ToString
. 6
(
6 7
)
7 8
,
8 9
PhoneNumber
 
=
 
$str
 &
,
& '"
PhoneNumberConfirmed
‘‘  
=
‘‘! "
true
‘‘# '
,
‘‘' (
TwoFactorEnabled
’’ 
=
’’ 
false
’’ $
,
’’$ %

LockoutEnd
““ 
=
““ 
null
““ 
,
““ 
LockoutEnabled
”” 
=
”” 
true
”” !
,
””! "
AccessFailedCount
•• 
=
•• 
$num
••  !
,
••! "

UpdateTime
–– 
=
–– 
new
–– 
DateTime
–– %
(
––% &
$num
––& *
,
––* +
$num
––, -
,
––- .
$num
––/ 1
)
––1 2
}
—— 	
;
——	 

modelBuilder
™™ 
.
™™ 
Entity
™™ 
<
™™ 
ApplicationUser
™™ +
>
™™+ ,
(
™™, -
)
™™- .
.
™™. /
HasData
™™/ 6
(
™™6 7
	adminUser
™™7 @
)
™™@ A
;
™™A B
modelBuilder
œœ 
.
œœ 
Entity
œœ 
<
œœ 
IdentityUserRole
œœ ,
<
œœ, -
string
œœ- 3
>
œœ3 4
>
œœ4 5
(
œœ5 6
)
œœ6 7
.
œœ7 8
HasData
œœ8 ?
(
œœ? @
new
œœ@ C
IdentityUserRole
œœD T
<
œœT U
string
œœU [
>
œœ[ \
{
 	
RoleId
 
=
 
adminRoleId
  
,
  !
UserId
ŸŸ 
=
ŸŸ 
adminUserId
ŸŸ  
}
   	
)
  	 

;
  
 
}
¡¡ 
}¢¢ ß'
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
}BB ”4
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
}99 ¬
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
} Å
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
} ï
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
}// ­0
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
}[[ ÿ
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
}.. ó
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
}   ¶
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
}$$ ù
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
} ª

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
} Ç
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
} €
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
} ÿ
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
}// 
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
} ı
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
}** û
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
} £
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
} İü
ˆD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240705052116_AddMoreColumnForLevelTable.cs
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
DateTimeKind	aax „
.
aa„ …
Utc
aa… ˆ
)
aaˆ ‰
.
aa‰ Š
AddTicks
aaŠ ’
(
aa’ “
$num
aa“ —
)
aa— ˜
,
aa˜ ™
$str
aaš ğ
,
aağ ñ
$str
aaò ˜
}
aa™ š
)
aaš ›
;
aa› œ
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
$str	ee} ‡
,
ee‡ ˆ
$str
ee‰ 
,
ee Ÿ
$str
ee  ¯
,
ee¯ °
$str
ee± À
,
eeÀ Á
$str
eeÂ Ï
,
eeÏ Ğ
$str
eeÑ İ
,
eeİ Ş
$str
eeß ç
,
eeç è
$str
eeé ö
,
eeö ÷
$str
eeø †
,
ee† ‡
$str
eeˆ ’
,
ee’ “
$str
ee”  
}
ee¡ ¢
,
ee¢ £
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
$str	hhH °
,
hh° ±
$str
hh² â
,
hhâ ã
$str
hhä í
,
hhí î
$str
hhï ÷
,
hh÷ ø
new
hhù ü
DateTime
hhı …
(
hh… †
$num
hh† Š
,
hhŠ ‹
$num
hhŒ 
,
hh 
$num
hh 
,
hh ‘
$num
hh’ ”
,
hh” •
$num
hh– ˜
,
hh˜ ™
$num
hhš œ
,
hhœ 
$num
hh ¡
,
hh¡ ¢
DateTimeKind
hh£ ¯
.
hh¯ °
Local
hh° µ
)
hhµ ¶
.
hh¶ ·
AddTicks
hh· ¿
(
hh¿ À
$num
hhÀ Ä
)
hhÄ Å
,
hhÅ Æ
$str
hhÇ ø
,
hhø ù
$str
hhú ƒ
,
hhƒ „
$str
hh… 
,
hh Ÿ
$str
hh  »
,
hh» ¼
$str
hh½ Ç
,
hhÇ È
$str
hhÉ å
,
hhå æ
$str
hhç ô
,
hhô õ
$num
hhö ÷
,
hh÷ ø
$str
hhù 
,
hh 
$str
hh 
,
hh 
$str
hhŸ ¦
,
hh¦ §
new
hh¨ «
DateTime
hh¬ ´
(
hh´ µ
$num
hhµ ¹
,
hh¹ º
$num
hh» ¼
,
hh¼ ½
$num
hh¾ ¿
,
hh¿ À
$num
hhÁ Ã
,
hhÃ Ä
$num
hhÅ Ç
,
hhÇ È
$num
hhÉ Ë
,
hhË Ì
$num
hhÍ Ğ
,
hhĞ Ñ
DateTimeKind
hhÒ Ş
.
hhŞ ß
Local
hhß ä
)
hhä å
.
hhå æ
AddTicks
hhæ î
(
hhî ï
$num
hhï ó
)
hhó ô
}
hhõ ö
,
hhö ÷
{ii 
newii 
Guidii 
(ii 
$strii E
)iiE F
,iiF G
$str	iiH 
,
ii 
$str
ii‘ Á
,
iiÁ Â
$str
iiÃ Ú
,
iiÚ Û
$str
iiÜ ä
,
iiä å
new
iiæ é
DateTime
iiê ò
(
iiò ó
$num
iió ÷
,
ii÷ ø
$num
iiù ú
,
iiú û
$num
iiü ı
,
iiı ş
$num
iiÿ 
,
ii ‚
$num
iiƒ …
,
ii… †
$num
ii‡ ‰
,
ii‰ Š
$num
ii‹ 
,
ii 
DateTimeKind
ii œ
.
iiœ 
Local
ii ¢
)
ii¢ £
.
ii£ ¤
AddTicks
ii¤ ¬
(
ii¬ ­
$num
ii­ ±
)
ii± ²
,
ii² ³
$str
ii´ å
,
iiå æ
$str
iiç ğ
,
iiğ ñ
$str
iiò ‹
,
ii‹ Œ
$str
ii ¯
,
ii¯ °
$str
ii± ½
,
ii½ ¾
$str
ii¿ Û
,
iiÛ Ü
$str
iiİ ê
,
iiê ë
$num
iiì í
,
iií î
$str
iiï 
,
ii 
$str
ii‘ ª
,
iiª «
$str
ii¬ ³
,
ii³ ´
new
iiµ ¸
DateTime
ii¹ Á
(
iiÁ Â
$num
iiÂ Æ
,
iiÆ Ç
$num
iiÈ É
,
iiÉ Ê
$num
iiË Ì
,
iiÌ Í
$num
iiÎ Ğ
,
iiĞ Ñ
$num
iiÒ Ô
,
iiÔ Õ
$num
iiÖ Ø
,
iiØ Ù
$num
iiÚ İ
,
iiİ Ş
DateTimeKind
iiß ë
.
iië ì
Local
iiì ñ
)
iiñ ò
.
iiò ó
AddTicks
iió û
(
iiû ü
$num
iiü €
)
ii€ 
}
ii‚ ƒ
,
iiƒ „
{jj 
newjj 
Guidjj 
(jj 
$strjj E
)jjE F
,jjF G
$strjjH s
,jjs t
$str	jju ™
,
jj™ š
$str
jj› ¥
,
jj¥ ¦
$str
jj§ ¯
,
jj¯ °
new
jj± ´
DateTime
jjµ ½
(
jj½ ¾
$num
jj¾ Â
,
jjÂ Ã
$num
jjÄ Å
,
jjÅ Æ
$num
jjÇ È
,
jjÈ É
$num
jjÊ Ì
,
jjÌ Í
$num
jjÎ Ğ
,
jjĞ Ñ
$num
jjÒ Ô
,
jjÔ Õ
$num
jjÖ Ù
,
jjÙ Ú
DateTimeKind
jjÛ ç
.
jjç è
Local
jjè í
)
jjí î
.
jjî ï
AddTicks
jjï ÷
(
jj÷ ø
$num
jjø ü
)
jjü ı
,
jjı ş
$str
jjÿ Å
,
jjÅ Æ
$str
jjÇ Ğ
,
jjĞ Ñ
$str
jjÒ ë
,
jjë ì
$str
jjí š
,
jjš ›
$str
jjœ ¨
,
jj¨ ©
$str
jjª Æ
,
jjÆ Ç
$str
jjÈ Õ
,
jjÕ Ö
$num
jj× Ø
,
jjØ Ù
$str
jjÚ ‡
,
jj‡ ˆ
$str
jj‰ ©
,
jj© ª
$str
jj« ²
,
jj² ³
new
jj´ ·
DateTime
jj¸ À
(
jjÀ Á
$num
jjÁ Å
,
jjÅ Æ
$num
jjÇ È
,
jjÈ É
$num
jjÊ Ë
,
jjË Ì
$num
jjÍ Ï
,
jjÏ Ğ
$num
jjÑ Ó
,
jjÓ Ô
$num
jjÕ ×
,
jj× Ø
$num
jjÙ Ü
,
jjÜ İ
DateTimeKind
jjŞ ê
.
jjê ë
Local
jjë ğ
)
jjğ ñ
.
jjñ ò
AddTicks
jjò ú
(
jjú û
$num
jjû ÿ
)
jjÿ €
}
jj ‚
,
jj‚ ƒ
{kk 
newkk 
Guidkk 
(kk 
$strkk E
)kkE F
,kkF G
$str	kkH 
,
kk 
$str
kk‘ Á
,
kkÁ Â
$str
kkÃ Ú
,
kkÚ Û
$str
kkÜ ä
,
kkä å
new
kkæ é
DateTime
kkê ò
(
kkò ó
$num
kkó ÷
,
kk÷ ø
$num
kkù ú
,
kkú û
$num
kkü ı
,
kkı ş
$num
kkÿ 
,
kk ‚
$num
kkƒ …
,
kk… †
$num
kk‡ ‰
,
kk‰ Š
$num
kk‹ 
,
kk 
DateTimeKind
kk œ
.
kkœ 
Local
kk ¢
)
kk¢ £
.
kk£ ¤
AddTicks
kk¤ ¬
(
kk¬ ­
$num
kk­ ±
)
kk± ²
,
kk² ³
$str
kk´ å
,
kkå æ
$str
kkç ğ
,
kkğ ñ
$str
kkò ‹
,
kk‹ Œ
$str
kk ³
,
kk³ ´
$str
kkµ Á
,
kkÁ Â
$str
kkÃ ß
,
kkß à
$str
kká î
,
kkî ï
$num
kkğ ñ
,
kkñ ò
$str
kkó “
,
kk“ ”
$str
kk• ­
,
kk­ ®
$str
kk¯ ¶
,
kk¶ ·
new
kk¸ »
DateTime
kk¼ Ä
(
kkÄ Å
$num
kkÅ É
,
kkÉ Ê
$num
kkË Ì
,
kkÌ Í
$num
kkÎ Ï
,
kkÏ Ğ
$num
kkÑ Ó
,
kkÓ Ô
$num
kkÕ ×
,
kk× Ø
$num
kkÙ Û
,
kkÛ Ü
$num
kkİ à
,
kkà á
DateTimeKind
kkâ î
.
kkî ï
Local
kkï ô
)
kkô õ
.
kkõ ö
AddTicks
kkö ş
(
kkş ÿ
$num
kkÿ ƒ
)
kkƒ „
}
kk… †
,
kk† ‡
{ll 
newll 
Guidll 
(ll 
$strll E
)llE F
,llF G
$str	llH 
,
ll Ÿ
$str
ll  Å
,
llÅ Æ
$str
llÇ Ï
,
llÏ Ğ
$str
llÑ Ù
,
llÙ Ú
new
llÛ Ş
DateTime
llß ç
(
llç è
$num
llè ì
,
llì í
$num
llî ï
,
llï ğ
$num
llñ ò
,
llò ó
$num
llô ö
,
llö ÷
$num
llø ú
,
llú û
$num
llü ş
,
llş ÿ
$num
ll€ ƒ
,
llƒ „
DateTimeKind
ll… ‘
.
ll‘ ’
Local
ll’ —
)
ll— ˜
.
ll˜ ™
AddTicks
ll™ ¡
(
ll¡ ¢
$num
ll¢ ¦
)
ll¦ §
,
ll§ ¨
$str
ll© Ú
,
llÚ Û
$str
llÜ å
,
llå æ
$str
llç 
,
ll ‚
$str
llƒ ›
,
ll› œ
$str
ll §
,
ll§ ¨
$str
ll© Å
,
llÅ Æ
$str
llÇ Ô
,
llÔ Õ
$num
llÖ ×
,
ll× Ø
$str
llÙ î
,
llî ï
$str
llğ 
,
ll ‚
$str
llƒ Š
,
llŠ ‹
new
llŒ 
DateTime
ll ˜
(
ll˜ ™
$num
ll™ 
,
ll 
$num
llŸ  
,
ll  ¡
$num
ll¢ £
,
ll£ ¤
$num
ll¥ §
,
ll§ ¨
$num
ll© «
,
ll« ¬
$num
ll­ ¯
,
ll¯ °
$num
ll± ´
,
ll´ µ
DateTimeKind
ll¶ Â
.
llÂ Ã
Local
llÃ È
)
llÈ É
.
llÉ Ê
AddTicks
llÊ Ò
(
llÒ Ó
$num
llÓ ×
)
ll× Ø
}
llÙ Ú
,
llÚ Û
{mm 
newmm 
Guidmm 
(mm 
$strmm E
)mmE F
,mmF G
$str	mmH ‘
,
mm‘ ’
$str
mm“ Ã
,
mmÃ Ä
$str
mmÅ ×
,
mm× Ø
$str
mmÙ á
,
mmá â
new
mmã æ
DateTime
mmç ï
(
mmï ğ
$num
mmğ ô
,
mmô õ
$num
mmö ÷
,
mm÷ ø
$num
mmù ú
,
mmú û
$num
mmü ş
,
mmş ÿ
$num
mm€ ‚
,
mm‚ ƒ
$num
mm„ †
,
mm† ‡
$num
mmˆ ‹
,
mm‹ Œ
DateTimeKind
mm ™
.
mm™ š
Local
mmš Ÿ
)
mmŸ  
.
mm  ¡
AddTicks
mm¡ ©
(
mm© ª
$num
mmª ®
)
mm® ¯
,
mm¯ °
$str
mm± â
,
mmâ ã
$str
mmä í
,
mmí î
$str
mmï ˆ
,
mmˆ ‰
$str
mmŠ ¨
,
mm¨ ©
$str
mmª ±
,
mm± ²
$str
mm³ Ï
,
mmÏ Ğ
$str
mmÑ Ş
,
mmŞ ß
$num
mmà á
,
mmá â
$str
mmã 
,
mm ‚
$str
mmƒ §
,
mm§ ¨
$str
mm© °
,
mm° ±
new
mm² µ
DateTime
mm¶ ¾
(
mm¾ ¿
$num
mm¿ Ã
,
mmÃ Ä
$num
mmÅ Æ
,
mmÆ Ç
$num
mmÈ É
,
mmÉ Ê
$num
mmË Í
,
mmÍ Î
$num
mmÏ Ñ
,
mmÑ Ò
$num
mmÓ Õ
,
mmÕ Ö
$num
mm× Ú
,
mmÚ Û
DateTimeKind
mmÜ è
.
mmè é
Local
mmé î
)
mmî ï
.
mmï ğ
AddTicks
mmğ ø
(
mmø ù
$num
mmù ı
)
mmı ş
}
mmÿ €
,
mm€ 
{nn 
newnn 
Guidnn 
(nn 
$strnn E
)nnE F
,nnF G
$str	nnH ¨
,
nn¨ ©
$str
nnª Ø
,
nnØ Ù
$str
nnÚ ä
,
nnä å
$str
nnæ î
,
nnî ï
new
nnğ ó
DateTime
nnô ü
(
nnü ı
$num
nnı 
,
nn ‚
$num
nnƒ „
,
nn„ …
$num
nn† ‡
,
nn‡ ˆ
$num
nn‰ ‹
,
nn‹ Œ
$num
nn 
,
nn 
$num
nn‘ “
,
nn“ ”
$num
nn• ˜
,
nn˜ ™
DateTimeKind
nnš ¦
.
nn¦ §
Local
nn§ ¬
)
nn¬ ­
.
nn­ ®
AddTicks
nn® ¶
(
nn¶ ·
$num
nn· »
)
nn» ¼
,
nn¼ ½
$str
nn¾ ï
,
nnï ğ
$str
nnñ ú
,
nnú û
$str
nnü –
,
nn– —
$str
nn˜ ¿
,
nn¿ À
$str
nnÁ Ë
,
nnË Ì
$str
nnÍ é
,
nné ê
$str
nnë ø
,
nnø ù
$num
nnú û
,
nnû ü
$str
nnı ’
,
nn’ “
$str
nn” ¤
,
nn¤ ¥
$str
nn¦ ­
,
nn­ ®
new
nn¯ ²
DateTime
nn³ »
(
nn» ¼
$num
nn¼ À
,
nnÀ Á
$num
nnÂ Ã
,
nnÃ Ä
$num
nnÅ Æ
,
nnÆ Ç
$num
nnÈ Ê
,
nnÊ Ë
$num
nnÌ Î
,
nnÎ Ï
$num
nnĞ Ò
,
nnÒ Ó
$num
nnÔ ×
,
nn× Ø
DateTimeKind
nnÙ å
.
nnå æ
Local
nnæ ë
)
nnë ì
.
nnì í
AddTicks
nní õ
(
nnõ ö
$num
nnö ú
)
nnú û
}
nnü ı
,
nnı ş
{oo 
newoo 
Guidoo 
(oo 
$stroo E
)ooE F
,ooF G
$str	ooH ¾
,
oo¾ ¿
$str
ooÀ 
,
oo Ÿ
$str
oo  ª
,
ooª «
$str
oo¬ ´
,
oo´ µ
new
oo¶ ¹
DateTime
ooº Â
(
ooÂ Ã
$num
ooÃ Ç
,
ooÇ È
$num
ooÉ Ê
,
ooÊ Ë
$num
ooÌ Í
,
ooÍ Î
$num
ooÏ Ñ
,
ooÑ Ò
$num
ooÓ Õ
,
ooÕ Ö
$num
oo× Ù
,
ooÙ Ú
$num
ooÛ Ş
,
ooŞ ß
DateTimeKind
ooà ì
.
ooì í
Local
ooí ò
)
ooò ó
.
ooó ô
AddTicks
ooô ü
(
ooü ı
$num
ooı 
)
oo ‚
,
oo‚ ƒ
$str
oo„ È
,
ooÈ É
$str
ooÊ Ó
,
ooÓ Ô
$str
ooÕ ú
,
ooú û
$str
ooü ¢
,
oo¢ £
$str
oo¤ ®
,
oo® ¯
$str
oo° Ì
,
ooÌ Í
$str
ooÎ Û
,
ooÛ Ü
$num
ooİ Ş
,
ooŞ ß
$str
ooà õ
,
ooõ ö
$str
oo÷ Œ
,
ooŒ 
$str
oo •
,
oo• –
new
oo— š
DateTime
oo› £
(
oo£ ¤
$num
oo¤ ¨
,
oo¨ ©
$num
ooª «
,
oo« ¬
$num
oo­ ®
,
oo® ¯
$num
oo° ²
,
oo² ³
$num
oo´ ¶
,
oo¶ ·
$num
oo¸ º
,
ooº »
$num
oo¼ ¿
,
oo¿ À
DateTimeKind
ooÁ Í
.
ooÍ Î
Local
ooÎ Ó
)
ooÓ Ô
.
ooÔ Õ
AddTicks
ooÕ İ
(
ooİ Ş
$num
ooŞ â
)
ooâ ã
}
ooä å
,
ooå æ
{pp 
newpp 
Guidpp 
(pp 
$strpp E
)ppE F
,ppF G
$str	ppH 
,
pp 
$str
pp‘ º
,
ppº »
$str
pp¼ Ê
,
ppÊ Ë
$str
ppÌ Ô
,
ppÔ Õ
new
ppÖ Ù
DateTime
ppÚ â
(
ppâ ã
$num
ppã ç
,
ppç è
$num
ppé ê
,
ppê ë
$num
ppì í
,
ppí î
$num
ppï ñ
,
ppñ ò
$num
ppó õ
,
ppõ ö
$num
pp÷ ù
,
ppù ú
$num
ppû ş
,
ppş ÿ
DateTimeKind
pp€ Œ
.
ppŒ 
Local
pp ’
)
pp’ “
.
pp“ ”
AddTicks
pp” œ
(
ppœ 
$num
pp ¡
)
pp¡ ¢
,
pp¢ £
$str
pp¤ Õ
,
ppÕ Ö
$str
pp× à
,
ppà á
$str
ppâ î
,
ppî ï
$str
ppğ €
,
pp€ 
$str
pp‚ Œ
,
ppŒ 
$str
pp ¤
,
pp¤ ¥
$str
pp¦ ²
,
pp² ³
$num
pp´ µ
,
ppµ ¶
$str
pp· È
,
ppÈ É
$str
ppÊ ß
,
ppß à
$str
ppá è
,
ppè é
new
ppê í
DateTime
ppî ö
(
ppö ÷
$num
pp÷ û
,
ppû ü
$num
ppı ş
,
ppş ÿ
$num
pp€ 
,
pp ‚
$num
ppƒ …
,
pp… †
$num
pp‡ ‰
,
pp‰ Š
$num
pp‹ 
,
pp 
$num
pp ’
,
pp’ “
DateTimeKind
pp”  
.
pp  ¡
Local
pp¡ ¦
)
pp¦ §
.
pp§ ¨
AddTicks
pp¨ °
(
pp° ±
$num
pp± µ
)
ppµ ¶
}
pp· ¸
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
 
.
 

DeleteData
 '
(
' (
table
‚‚ 
:
‚‚ 
$str
‚‚ '
,
‚‚' (
	keyColumn
ƒƒ 
:
ƒƒ 
$str
ƒƒ 
,
ƒƒ  
keyValue
„„ 
:
„„ 
new
„„ 
Guid
„„ "
(
„„" #
$str
„„# I
)
„„I J
)
„„J K
;
„„K L
migrationBuilder
†† 
.
†† 

DeleteData
†† '
(
††' (
table
‡‡ 
:
‡‡ 
$str
‡‡ '
,
‡‡' (
	keyColumn
ˆˆ 
:
ˆˆ 
$str
ˆˆ 
,
ˆˆ  
keyValue
‰‰ 
:
‰‰ 
new
‰‰ 
Guid
‰‰ "
(
‰‰" #
$str
‰‰# I
)
‰‰I J
)
‰‰J K
;
‰‰K L
migrationBuilder
‹‹ 
.
‹‹ 

DeleteData
‹‹ '
(
‹‹' (
table
ŒŒ 
:
ŒŒ 
$str
ŒŒ '
,
ŒŒ' (
	keyColumn
 
:
 
$str
 
,
  
keyValue
 
:
 
new
 
Guid
 "
(
" #
$str
# I
)
I J
)
J K
;
K L
migrationBuilder
 
.
 

DeleteData
 '
(
' (
table
‘‘ 
:
‘‘ 
$str
‘‘ '
,
‘‘' (
	keyColumn
’’ 
:
’’ 
$str
’’ 
,
’’  
keyValue
““ 
:
““ 
new
““ 
Guid
““ "
(
““" #
$str
““# I
)
““I J
)
““J K
;
““K L
migrationBuilder
•• 
.
•• 

DeleteData
•• '
(
••' (
table
–– 
:
–– 
$str
–– '
,
––' (
	keyColumn
—— 
:
—— 
$str
—— 
,
——  
keyValue
˜˜ 
:
˜˜ 
new
˜˜ 
Guid
˜˜ "
(
˜˜" #
$str
˜˜# I
)
˜˜I J
)
˜˜J K
;
˜˜K L
migrationBuilder
šš 
.
šš 

DeleteData
šš '
(
šš' (
table
›› 
:
›› 
$str
›› '
,
››' (
	keyColumn
œœ 
:
œœ 
$str
œœ 
,
œœ  
keyValue
 
:
 
new
 
Guid
 "
(
" #
$str
# I
)
I J
)
J K
;
K L
migrationBuilder
ŸŸ 
.
ŸŸ 

DeleteData
ŸŸ '
(
ŸŸ' (
table
   
:
   
$str
   '
,
  ' (
	keyColumn
¡¡ 
:
¡¡ 
$str
¡¡ 
,
¡¡  
keyValue
¢¢ 
:
¢¢ 
new
¢¢ 
Guid
¢¢ "
(
¢¢" #
$str
¢¢# I
)
¢¢I J
)
¢¢J K
;
¢¢K L
migrationBuilder
¤¤ 
.
¤¤ 

DropColumn
¤¤ '
(
¤¤' (
name
¥¥ 
:
¥¥ 
$str
¥¥  
,
¥¥  !
table
¦¦ 
:
¦¦ 
$str
¦¦ 
)
¦¦  
;
¦¦  !
migrationBuilder
¨¨ 
.
¨¨ 

DropColumn
¨¨ '
(
¨¨' (
name
©© 
:
©© 
$str
©© "
,
©©" #
table
ªª 
:
ªª 
$str
ªª 
)
ªª  
;
ªª  !
migrationBuilder
¬¬ 
.
¬¬ 

DropColumn
¬¬ '
(
¬¬' (
name
­­ 
:
­­ 
$str
­­ 
,
­­ 
table
®® 
:
®® 
$str
®® 
)
®®  
;
®®  !
migrationBuilder
°° 
.
°° 

DropColumn
°° '
(
°°' (
name
±± 
:
±± 
$str
±±  
,
±±  !
table
²² 
:
²² 
$str
²² 
)
²²  
;
²²  !
migrationBuilder
´´ 
.
´´ 

DropColumn
´´ '
(
´´' (
name
µµ 
:
µµ 
$str
µµ "
,
µµ" #
table
¶¶ 
:
¶¶ 
$str
¶¶ 
)
¶¶  
;
¶¶  !
migrationBuilder
¸¸ 
.
¸¸ 

UpdateData
¸¸ '
(
¸¸' (
table
¹¹ 
:
¹¹ 
$str
¹¹ $
,
¹¹$ %
	keyColumn
ºº 
:
ºº 
$str
ºº 
,
ºº  
keyValue
»» 
:
»» 
$str
»» +
,
»»+ ,
columns
¼¼ 
:
¼¼ 
new
¼¼ 
[
¼¼ 
]
¼¼ 
{
¼¼  
$str
¼¼! 3
,
¼¼3 4
$str
¼¼5 A
,
¼¼A B
$str
¼¼C Q
,
¼¼Q R
$str
¼¼S b
}
¼¼c d
,
¼¼d e
values
½½ 
:
½½ 
new
½½ 
object
½½ "
[
½½" #
]
½½# $
{
½½% &
$str
½½' M
,
½½M N
new
½½O R
DateTime
½½S [
(
½½[ \
$num
½½\ `
,
½½` a
$num
½½b c
,
½½c d
$num
½½e f
,
½½f g
$num
½½h j
,
½½j k
$num
½½l n
,
½½n o
$num
½½p r
,
½½r s
$num
½½t w
,
½½w x
DateTimeKind½½y …
.½½… †
Utc½½† ‰
)½½‰ Š
.½½Š ‹
AddTicks½½‹ “
(½½“ ”
$num½½” ˜
)½½˜ ™
,½½™ š
$str½½› ñ
,½½ñ ò
$str½½ó ™
}½½š ›
)½½› œ
;½½œ 
migrationBuilder
¿¿ 
.
¿¿ 

InsertData
¿¿ '
(
¿¿' (
table
ÀÀ 
:
ÀÀ 
$str
ÀÀ '
,
ÀÀ' (
columns
ÁÁ 
:
ÁÁ 
new
ÁÁ 
[
ÁÁ 
]
ÁÁ 
{
ÁÁ  
$str
ÁÁ! %
,
ÁÁ% &
$str
ÁÁ' 4
,
ÁÁ4 5
$str
ÁÁ6 D
,
ÁÁD E
$str
ÁÁF P
,
ÁÁP Q
$str
ÁÁR \
,
ÁÁ\ ]
$str
ÁÁ^ j
,
ÁÁj k
$str
ÁÁl {
,
ÁÁ{ |
$strÁÁ} ‡
,ÁÁ‡ ˆ
$strÁÁ‰ 
,ÁÁ Ÿ
$strÁÁ  ¯
,ÁÁ¯ °
$strÁÁ± À
,ÁÁÀ Á
$strÁÁÂ Ï
,ÁÁÏ Ğ
$strÁÁÑ İ
,ÁÁİ Ş
$strÁÁß ç
,ÁÁç è
$strÁÁé ö
,ÁÁö ÷
$strÁÁø †
,ÁÁ† ‡
$strÁÁˆ ’
,ÁÁ’ “
$strÁÁ”  
}ÁÁ¡ ¢
,ÁÁ¢ £
values
ÂÂ 
:
ÂÂ 
new
ÂÂ 
object
ÂÂ "
[
ÂÂ" #
,
ÂÂ# $
]
ÂÂ$ %
{
ÃÃ 
{
ÄÄ 
new
ÄÄ 
Guid
ÄÄ 
(
ÄÄ 
$str
ÄÄ E
)
ÄÄE F
,
ÄÄF G
$strÄÄH ¨
,ÄÄ¨ ©
$strÄÄª Ø
,ÄÄØ Ù
$strÄÄÚ ä
,ÄÄä å
$strÄÄæ î
,ÄÄî ï
newÄÄğ ó
DateTimeÄÄô ü
(ÄÄü ı
$numÄÄı 
,ÄÄ ‚
$numÄÄƒ „
,ÄÄ„ …
$numÄÄ† ‡
,ÄÄ‡ ˆ
$numÄÄ‰ ‹
,ÄÄ‹ Œ
$numÄÄ 
,ÄÄ 
$numÄÄ‘ “
,ÄÄ“ ”
$numÄÄ• ˜
,ÄÄ˜ ™
DateTimeKindÄÄš ¦
.ÄÄ¦ §
LocalÄÄ§ ¬
)ÄÄ¬ ­
.ÄÄ­ ®
AddTicksÄÄ® ¶
(ÄÄ¶ ·
$numÄÄ· ¹
)ÄÄ¹ º
,ÄÄº »
$strÄÄ¼ í
,ÄÄí î
$strÄÄï ø
,ÄÄø ù
$strÄÄú ”
,ÄÄ” •
$strÄÄ– ½
,ÄÄ½ ¾
$strÄÄ¿ É
,ÄÄÉ Ê
$strÄÄË ç
,ÄÄç è
$strÄÄé ö
,ÄÄö ÷
$numÄÄø ù
,ÄÄù ú
$strÄÄû 
,ÄÄ ‘
$strÄÄ’ ¢
,ÄÄ¢ £
$strÄÄ¤ «
,ÄÄ« ¬
newÄÄ­ °
DateTimeÄÄ± ¹
(ÄÄ¹ º
$numÄÄº ¾
,ÄÄ¾ ¿
$numÄÄÀ Á
,ÄÄÁ Â
$numÄÄÃ Ä
,ÄÄÄ Å
$numÄÄÆ È
,ÄÄÈ É
$numÄÄÊ Ì
,ÄÄÌ Í
$numÄÄÎ Ğ
,ÄÄĞ Ñ
$numÄÄÒ Õ
,ÄÄÕ Ö
DateTimeKindÄÄ× ã
.ÄÄã ä
LocalÄÄä é
)ÄÄé ê
.ÄÄê ë
AddTicksÄÄë ó
(ÄÄó ô
$numÄÄô ö
)ÄÄö ÷
}ÄÄø ù
,ÄÄù ú
{
ÅÅ 
new
ÅÅ 
Guid
ÅÅ 
(
ÅÅ 
$str
ÅÅ E
)
ÅÅE F
,
ÅÅF G
$strÅÅH 
,ÅÅ Ÿ
$strÅÅ  Å
,ÅÅÅ Æ
$strÅÅÇ Ï
,ÅÅÏ Ğ
$strÅÅÑ Ù
,ÅÅÙ Ú
newÅÅÛ Ş
DateTimeÅÅß ç
(ÅÅç è
$numÅÅè ì
,ÅÅì í
$numÅÅî ï
,ÅÅï ğ
$numÅÅñ ò
,ÅÅò ó
$numÅÅô ö
,ÅÅö ÷
$numÅÅø ú
,ÅÅú û
$numÅÅü ş
,ÅÅş ÿ
$numÅÅ€ ƒ
,ÅÅƒ „
DateTimeKindÅÅ… ‘
.ÅÅ‘ ’
LocalÅÅ’ —
)ÅÅ— ˜
.ÅÅ˜ ™
AddTicksÅÅ™ ¡
(ÅÅ¡ ¢
$numÅÅ¢ ¤
)ÅÅ¤ ¥
,ÅÅ¥ ¦
$strÅÅ§ Ø
,ÅÅØ Ù
$strÅÅÚ ã
,ÅÅã ä
$strÅÅå ÿ
,ÅÅÿ €
$strÅÅ ™
,ÅÅ™ š
$strÅÅ› ¥
,ÅÅ¥ ¦
$strÅÅ§ Ã
,ÅÅÃ Ä
$strÅÅÅ Ò
,ÅÅÒ Ó
$numÅÅÔ Õ
,ÅÅÕ Ö
$strÅÅ× ì
,ÅÅì í
$strÅÅî ÿ
,ÅÅÿ €
$strÅÅ ˆ
,ÅÅˆ ‰
newÅÅŠ 
DateTimeÅÅ –
(ÅÅ– —
$numÅÅ— ›
,ÅÅ› œ
$numÅÅ 
,ÅÅ Ÿ
$numÅÅ  ¡
,ÅÅ¡ ¢
$numÅÅ£ ¥
,ÅÅ¥ ¦
$numÅÅ§ ©
,ÅÅ© ª
$numÅÅ« ­
,ÅÅ­ ®
$numÅÅ¯ ²
,ÅÅ² ³
DateTimeKindÅÅ´ À
.ÅÅÀ Á
LocalÅÅÁ Æ
)ÅÅÆ Ç
.ÅÅÇ È
AddTicksÅÅÈ Ğ
(ÅÅĞ Ñ
$numÅÅÑ Ó
)ÅÅÓ Ô
}ÅÅÕ Ö
,ÅÅÖ ×
{
ÆÆ 
new
ÆÆ 
Guid
ÆÆ 
(
ÆÆ 
$str
ÆÆ E
)
ÆÆE F
,
ÆÆF G
$strÆÆH ‘
,ÆÆ‘ ’
$strÆÆ“ Ã
,ÆÆÃ Ä
$strÆÆÅ ×
,ÆÆ× Ø
$strÆÆÙ á
,ÆÆá â
newÆÆã æ
DateTimeÆÆç ï
(ÆÆï ğ
$numÆÆğ ô
,ÆÆô õ
$numÆÆö ÷
,ÆÆ÷ ø
$numÆÆù ú
,ÆÆú û
$numÆÆü ş
,ÆÆş ÿ
$numÆÆ€ ‚
,ÆÆ‚ ƒ
$numÆÆ„ †
,ÆÆ† ‡
$numÆÆˆ ‹
,ÆÆ‹ Œ
DateTimeKindÆÆ ™
.ÆÆ™ š
LocalÆÆš Ÿ
)ÆÆŸ  
.ÆÆ  ¡
AddTicksÆÆ¡ ©
(ÆÆ© ª
$numÆÆª ¬
)ÆÆ¬ ­
,ÆÆ­ ®
$strÆÆ¯ à
,ÆÆà á
$strÆÆâ ë
,ÆÆë ì
$strÆÆí †
,ÆÆ† ‡
$strÆÆˆ ¦
,ÆÆ¦ §
$strÆÆ¨ ¯
,ÆÆ¯ °
$strÆÆ± Í
,ÆÆÍ Î
$strÆÆÏ Ü
,ÆÆÜ İ
$numÆÆŞ ß
,ÆÆß à
$strÆÆá ÿ
,ÆÆÿ €
$strÆÆ ¥
,ÆÆ¥ ¦
$strÆÆ§ ®
,ÆÆ® ¯
newÆÆ° ³
DateTimeÆÆ´ ¼
(ÆÆ¼ ½
$numÆÆ½ Á
,ÆÆÁ Â
$numÆÆÃ Ä
,ÆÆÄ Å
$numÆÆÆ Ç
,ÆÆÇ È
$numÆÆÉ Ë
,ÆÆË Ì
$numÆÆÍ Ï
,ÆÆÏ Ğ
$numÆÆÑ Ó
,ÆÆÓ Ô
$numÆÆÕ Ø
,ÆÆØ Ù
DateTimeKindÆÆÚ æ
.ÆÆæ ç
LocalÆÆç ì
)ÆÆì í
.ÆÆí î
AddTicksÆÆî ö
(ÆÆö ÷
$numÆÆ÷ ù
)ÆÆù ú
}ÆÆû ü
,ÆÆü ı
{
ÇÇ 
new
ÇÇ 
Guid
ÇÇ 
(
ÇÇ 
$str
ÇÇ E
)
ÇÇE F
,
ÇÇF G
$str
ÇÇH s
,
ÇÇs t
$strÇÇu ™
,ÇÇ™ š
$strÇÇ› ¥
,ÇÇ¥ ¦
$strÇÇ§ ¯
,ÇÇ¯ °
newÇÇ± ´
DateTimeÇÇµ ½
(ÇÇ½ ¾
$numÇÇ¾ Â
,ÇÇÂ Ã
$numÇÇÄ Å
,ÇÇÅ Æ
$numÇÇÇ È
,ÇÇÈ É
$numÇÇÊ Ì
,ÇÇÌ Í
$numÇÇÎ Ğ
,ÇÇĞ Ñ
$numÇÇÒ Ô
,ÇÇÔ Õ
$numÇÇÖ Ù
,ÇÇÙ Ú
DateTimeKindÇÇÛ ç
.ÇÇç è
LocalÇÇè í
)ÇÇí î
.ÇÇî ï
AddTicksÇÇï ÷
(ÇÇ÷ ø
$numÇÇø ú
)ÇÇú û
,ÇÇû ü
$strÇÇı Ã
,ÇÇÃ Ä
$strÇÇÅ Î
,ÇÇÎ Ï
$strÇÇĞ é
,ÇÇé ê
$strÇÇë ˜
,ÇÇ˜ ™
$strÇÇš ¦
,ÇÇ¦ §
$strÇÇ¨ Ä
,ÇÇÄ Å
$strÇÇÆ Ó
,ÇÇÓ Ô
$numÇÇÕ Ö
,ÇÇÖ ×
$strÇÇØ …
,ÇÇ… †
$strÇÇ‡ §
,ÇÇ§ ¨
$strÇÇ© °
,ÇÇ° ±
newÇÇ² µ
DateTimeÇÇ¶ ¾
(ÇÇ¾ ¿
$numÇÇ¿ Ã
,ÇÇÃ Ä
$numÇÇÅ Æ
,ÇÇÆ Ç
$numÇÇÈ É
,ÇÇÉ Ê
$numÇÇË Í
,ÇÇÍ Î
$numÇÇÏ Ñ
,ÇÇÑ Ò
$numÇÇÓ Õ
,ÇÇÕ Ö
$numÇÇ× Ú
,ÇÇÚ Û
DateTimeKindÇÇÜ è
.ÇÇè é
LocalÇÇé î
)ÇÇî ï
.ÇÇï ğ
AddTicksÇÇğ ø
(ÇÇø ù
$numÇÇù û
)ÇÇû ü
}ÇÇı ş
,ÇÇş ÿ
{
ÈÈ 
new
ÈÈ 
Guid
ÈÈ 
(
ÈÈ 
$str
ÈÈ E
)
ÈÈE F
,
ÈÈF G
$strÈÈH ¾
,ÈÈ¾ ¿
$strÈÈÀ 
,ÈÈ Ÿ
$strÈÈ  ª
,ÈÈª «
$strÈÈ¬ ´
,ÈÈ´ µ
newÈÈ¶ ¹
DateTimeÈÈº Â
(ÈÈÂ Ã
$numÈÈÃ Ç
,ÈÈÇ È
$numÈÈÉ Ê
,ÈÈÊ Ë
$numÈÈÌ Í
,ÈÈÍ Î
$numÈÈÏ Ñ
,ÈÈÑ Ò
$numÈÈÓ Õ
,ÈÈÕ Ö
$numÈÈ× Ù
,ÈÈÙ Ú
$numÈÈÛ Ş
,ÈÈŞ ß
DateTimeKindÈÈà ì
.ÈÈì í
LocalÈÈí ò
)ÈÈò ó
.ÈÈó ô
AddTicksÈÈô ü
(ÈÈü ı
$numÈÈı ÿ
)ÈÈÿ €
,ÈÈ€ 
$strÈÈ‚ Æ
,ÈÈÆ Ç
$strÈÈÈ Ñ
,ÈÈÑ Ò
$strÈÈÓ ø
,ÈÈø ù
$strÈÈú  
,ÈÈ  ¡
$strÈÈ¢ ¬
,ÈÈ¬ ­
$strÈÈ® Ê
,ÈÈÊ Ë
$strÈÈÌ Ù
,ÈÈÙ Ú
$numÈÈÛ Ü
,ÈÈÜ İ
$strÈÈŞ ó
,ÈÈó ô
$strÈÈõ Š
,ÈÈŠ ‹
$strÈÈŒ “
,ÈÈ“ ”
newÈÈ• ˜
DateTimeÈÈ™ ¡
(ÈÈ¡ ¢
$numÈÈ¢ ¦
,ÈÈ¦ §
$numÈÈ¨ ©
,ÈÈ© ª
$numÈÈ« ¬
,ÈÈ¬ ­
$numÈÈ® °
,ÈÈ° ±
$numÈÈ² ´
,ÈÈ´ µ
$numÈÈ¶ ¸
,ÈÈ¸ ¹
$numÈÈº ½
,ÈÈ½ ¾
DateTimeKindÈÈ¿ Ë
.ÈÈË Ì
LocalÈÈÌ Ñ
)ÈÈÑ Ò
.ÈÈÒ Ó
AddTicksÈÈÓ Û
(ÈÈÛ Ü
$numÈÈÜ Ş
)ÈÈŞ ß
}ÈÈà á
,ÈÈá â
{
ÉÉ 
new
ÉÉ 
Guid
ÉÉ 
(
ÉÉ 
$str
ÉÉ E
)
ÉÉE F
,
ÉÉF G
$strÉÉH 
,ÉÉ 
$strÉÉ‘ Á
,ÉÉÁ Â
$strÉÉÃ Ú
,ÉÉÚ Û
$strÉÉÜ ä
,ÉÉä å
newÉÉæ é
DateTimeÉÉê ò
(ÉÉò ó
$numÉÉó ÷
,ÉÉ÷ ø
$numÉÉù ú
,ÉÉú û
$numÉÉü ı
,ÉÉı ş
$numÉÉÿ 
,ÉÉ ‚
$numÉÉƒ …
,ÉÉ… †
$numÉÉ‡ ‰
,ÉÉ‰ Š
$numÉÉ‹ 
,ÉÉ 
DateTimeKindÉÉ œ
.ÉÉœ 
LocalÉÉ ¢
)ÉÉ¢ £
.ÉÉ£ ¤
AddTicksÉÉ¤ ¬
(ÉÉ¬ ­
$numÉÉ­ ¯
)ÉÉ¯ °
,ÉÉ° ±
$strÉÉ² ã
,ÉÉã ä
$strÉÉå î
,ÉÉî ï
$strÉÉğ ‰
,ÉÉ‰ Š
$strÉÉ‹ ±
,ÉÉ± ²
$strÉÉ³ ¿
,ÉÉ¿ À
$strÉÉÁ İ
,ÉÉİ Ş
$strÉÉß ì
,ÉÉì í
$numÉÉî ï
,ÉÉï ğ
$strÉÉñ ‘
,ÉÉ‘ ’
$strÉÉ“ «
,ÉÉ« ¬
$strÉÉ­ ´
,ÉÉ´ µ
newÉÉ¶ ¹
DateTimeÉÉº Â
(ÉÉÂ Ã
$numÉÉÃ Ç
,ÉÉÇ È
$numÉÉÉ Ê
,ÉÉÊ Ë
$numÉÉÌ Í
,ÉÉÍ Î
$numÉÉÏ Ñ
,ÉÉÑ Ò
$numÉÉÓ Õ
,ÉÉÕ Ö
$numÉÉ× Ù
,ÉÉÙ Ú
$numÉÉÛ Ş
,ÉÉŞ ß
DateTimeKindÉÉà ì
.ÉÉì í
LocalÉÉí ò
)ÉÉò ó
.ÉÉó ô
AddTicksÉÉô ü
(ÉÉü ı
$numÉÉı ÿ
)ÉÉÿ €
}ÉÉ ‚
,ÉÉ‚ ƒ
{
ÊÊ 
new
ÊÊ 
Guid
ÊÊ 
(
ÊÊ 
$str
ÊÊ E
)
ÊÊE F
,
ÊÊF G
$strÊÊH 
,ÊÊ 
$strÊÊ‘ º
,ÊÊº »
$strÊÊ¼ Ê
,ÊÊÊ Ë
$strÊÊÌ Ô
,ÊÊÔ Õ
newÊÊÖ Ù
DateTimeÊÊÚ â
(ÊÊâ ã
$numÊÊã ç
,ÊÊç è
$numÊÊé ê
,ÊÊê ë
$numÊÊì í
,ÊÊí î
$numÊÊï ñ
,ÊÊñ ò
$numÊÊó õ
,ÊÊõ ö
$numÊÊ÷ ù
,ÊÊù ú
$numÊÊû ş
,ÊÊş ÿ
DateTimeKindÊÊ€ Œ
.ÊÊŒ 
LocalÊÊ ’
)ÊÊ’ “
.ÊÊ“ ”
AddTicksÊÊ” œ
(ÊÊœ 
$numÊÊ Ÿ
)ÊÊŸ  
,ÊÊ  ¡
$strÊÊ¢ Ó
,ÊÊÓ Ô
$strÊÊÕ Ş
,ÊÊŞ ß
$strÊÊà ì
,ÊÊì í
$strÊÊî ş
,ÊÊş ÿ
$strÊÊ€ Š
,ÊÊŠ ‹
$strÊÊŒ ¢
,ÊÊ¢ £
$strÊÊ¤ °
,ÊÊ° ±
$numÊÊ² ³
,ÊÊ³ ´
$strÊÊµ Æ
,ÊÊÆ Ç
$strÊÊÈ İ
,ÊÊİ Ş
$strÊÊß æ
,ÊÊæ ç
newÊÊè ë
DateTimeÊÊì ô
(ÊÊô õ
$numÊÊõ ù
,ÊÊù ú
$numÊÊû ü
,ÊÊü ı
$numÊÊş ÿ
,ÊÊÿ €
$numÊÊ ƒ
,ÊÊƒ „
$numÊÊ… ‡
,ÊÊ‡ ˆ
$numÊÊ‰ ‹
,ÊÊ‹ Œ
$numÊÊ 
,ÊÊ ‘
DateTimeKindÊÊ’ 
.ÊÊ Ÿ
LocalÊÊŸ ¤
)ÊÊ¤ ¥
.ÊÊ¥ ¦
AddTicksÊÊ¦ ®
(ÊÊ® ¯
$numÊÊ¯ ±
)ÊÊ± ²
}ÊÊ³ ´
,ÊÊ´ µ
{
ËË 
new
ËË 
Guid
ËË 
(
ËË 
$str
ËË E
)
ËËE F
,
ËËF G
$strËËH °
,ËË° ±
$strËË² â
,ËËâ ã
$strËËä í
,ËËí î
$strËËï ÷
,ËË÷ ø
newËËù ü
DateTimeËËı …
(ËË… †
$numËË† Š
,ËËŠ ‹
$numËËŒ 
,ËË 
$numËË 
,ËË ‘
$numËË’ ”
,ËË” •
$numËË– ˜
,ËË˜ ™
$numËËš œ
,ËËœ 
$numËË ¡
,ËË¡ ¢
DateTimeKindËË£ ¯
.ËË¯ °
LocalËË° µ
)ËËµ ¶
.ËË¶ ·
AddTicksËË· ¿
(ËË¿ À
$numËËÀ Ä
)ËËÄ Å
,ËËÅ Æ
$strËËÇ ø
,ËËø ù
$strËËú ƒ
,ËËƒ „
$strËË… 
,ËË Ÿ
$strËË  »
,ËË» ¼
$strËË½ Ç
,ËËÇ È
$strËËÉ å
,ËËå æ
$strËËç ô
,ËËô õ
$numËËö ÷
,ËË÷ ø
$strËËù 
,ËË 
$strËË 
,ËË 
$strËËŸ ¦
,ËË¦ §
newËË¨ «
DateTimeËË¬ ´
(ËË´ µ
$numËËµ ¹
,ËË¹ º
$numËË» ¼
,ËË¼ ½
$numËË¾ ¿
,ËË¿ À
$numËËÁ Ã
,ËËÃ Ä
$numËËÅ Ç
,ËËÇ È
$numËËÉ Ë
,ËËË Ì
$numËËÍ Ğ
,ËËĞ Ñ
DateTimeKindËËÒ Ş
.ËËŞ ß
LocalËËß ä
)ËËä å
.ËËå æ
AddTicksËËæ î
(ËËî ï
$numËËï ó
)ËËó ô
}ËËõ ö
,ËËö ÷
{
ÌÌ 
new
ÌÌ 
Guid
ÌÌ 
(
ÌÌ 
$str
ÌÌ E
)
ÌÌE F
,
ÌÌF G
$strÌÌH 
,ÌÌ 
$strÌÌ‘ Á
,ÌÌÁ Â
$strÌÌÃ Ú
,ÌÌÚ Û
$strÌÌÜ ä
,ÌÌä å
newÌÌæ é
DateTimeÌÌê ò
(ÌÌò ó
$numÌÌó ÷
,ÌÌ÷ ø
$numÌÌù ú
,ÌÌú û
$numÌÌü ı
,ÌÌı ş
$numÌÌÿ 
,ÌÌ ‚
$numÌÌƒ …
,ÌÌ… †
$numÌÌ‡ ‰
,ÌÌ‰ Š
$numÌÌ‹ 
,ÌÌ 
DateTimeKindÌÌ œ
.ÌÌœ 
LocalÌÌ ¢
)ÌÌ¢ £
.ÌÌ£ ¤
AddTicksÌÌ¤ ¬
(ÌÌ¬ ­
$numÌÌ­ ¯
)ÌÌ¯ °
,ÌÌ° ±
$strÌÌ² ã
,ÌÌã ä
$strÌÌå î
,ÌÌî ï
$strÌÌğ ‰
,ÌÌ‰ Š
$strÌÌ‹ ­
,ÌÌ­ ®
$strÌÌ¯ »
,ÌÌ» ¼
$strÌÌ½ Ù
,ÌÌÙ Ú
$strÌÌÛ è
,ÌÌè é
$numÌÌê ë
,ÌÌë ì
$strÌÌí 
,ÌÌ 
$strÌÌ ¨
,ÌÌ¨ ©
$strÌÌª ±
,ÌÌ± ²
newÌÌ³ ¶
DateTimeÌÌ· ¿
(ÌÌ¿ À
$numÌÌÀ Ä
,ÌÌÄ Å
$numÌÌÆ Ç
,ÌÌÇ È
$numÌÌÉ Ê
,ÌÌÊ Ë
$numÌÌÌ Î
,ÌÌÎ Ï
$numÌÌĞ Ò
,ÌÌÒ Ó
$numÌÌÔ Ö
,ÌÌÖ ×
$numÌÌØ Û
,ÌÌÛ Ü
DateTimeKindÌÌİ é
.ÌÌé ê
LocalÌÌê ï
)ÌÌï ğ
.ÌÌğ ñ
AddTicksÌÌñ ù
(ÌÌù ú
$numÌÌú ü
)ÌÌü ı
}ÌÌş ÿ
}
ÍÍ 
)
ÍÍ 
;
ÍÍ 
}
ÎÎ 	
}
ÏÏ 
}ĞĞ ½µ
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240704123625_ModifiedDataSeeding.cs
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
DateTimeKind	y …
.
… †
Utc
† ‰
)
‰ Š
.
Š ‹
AddTicks
‹ “
(
“ ”
$num
” ˜
)
˜ ™
,
™ š
$str
› ñ
,
ñ ò
$str
ó ™
}
š ›
)
› œ
;
œ 
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
$str	} ‡
,
‡ ˆ
$str
‰ 
,
 Ÿ
$str
  ¯
,
¯ °
$str
± À
,
À Á
$str
Â Ï
,
Ï Ğ
$str
Ñ İ
,
İ Ş
$str
ß ç
,
ç è
$str
é ö
,
ö ÷
$str
ø †
,
† ‡
$str
ˆ ’
,
’ “
$str
”  
}
¡ ¢
,
¢ £
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
$str	H ¨
,
¨ ©
$str
ª Ø
,
Ø Ù
$str
Ú ä
,
ä å
$str
æ î
,
î ï
new
ğ ó
DateTime
ô ü
(
ü ı
$num
ı 
,
 ‚
$num
ƒ „
,
„ …
$num
† ‡
,
‡ ˆ
$num
‰ ‹
,
‹ Œ
$num
 
,
 
$num
‘ “
,
“ ”
$num
• ˜
,
˜ ™
DateTimeKind
š ¦
.
¦ §
Local
§ ¬
)
¬ ­
.
­ ®
AddTicks
® ¶
(
¶ ·
$num
· ¹
)
¹ º
,
º »
$str
¼ í
,
í î
$str
ï ø
,
ø ù
$str
ú ”
,
” •
$str
– ½
,
½ ¾
$str
¿ É
,
É Ê
$str
Ë ç
,
ç è
$str
é ö
,
ö ÷
$num
ø ù
,
ù ú
$str
û 
,
 ‘
$str
’ ¢
,
¢ £
$str
¤ «
,
« ¬
new
­ °
DateTime
± ¹
(
¹ º
$num
º ¾
,
¾ ¿
$num
À Á
,
Á Â
$num
Ã Ä
,
Ä Å
$num
Æ È
,
È É
$num
Ê Ì
,
Ì Í
$num
Î Ğ
,
Ğ Ñ
$num
Ò Õ
,
Õ Ö
DateTimeKind
× ã
.
ã ä
Local
ä é
)
é ê
.
ê ë
AddTicks
ë ó
(
ó ô
$num
ô ö
)
ö ÷
}
ø ù
,
ù ú
{ 
new 
Guid 
( 
$str E
)E F
,F G
$str	H 
,
 Ÿ
$str
  Å
,
Å Æ
$str
Ç Ï
,
Ï Ğ
$str
Ñ Ù
,
Ù Ú
new
Û Ş
DateTime
ß ç
(
ç è
$num
è ì
,
ì í
$num
î ï
,
ï ğ
$num
ñ ò
,
ò ó
$num
ô ö
,
ö ÷
$num
ø ú
,
ú û
$num
ü ş
,
ş ÿ
$num
€ ƒ
,
ƒ „
DateTimeKind
… ‘
.
‘ ’
Local
’ —
)
— ˜
.
˜ ™
AddTicks
™ ¡
(
¡ ¢
$num
¢ ¤
)
¤ ¥
,
¥ ¦
$str
§ Ø
,
Ø Ù
$str
Ú ã
,
ã ä
$str
å ÿ
,
ÿ €
$str
 ™
,
™ š
$str
› ¥
,
¥ ¦
$str
§ Ã
,
Ã Ä
$str
Å Ò
,
Ò Ó
$num
Ô Õ
,
Õ Ö
$str
× ì
,
ì í
$str
î ÿ
,
ÿ €
$str
 ˆ
,
ˆ ‰
new
Š 
DateTime
 –
(
– —
$num
— ›
,
› œ
$num
 
,
 Ÿ
$num
  ¡
,
¡ ¢
$num
£ ¥
,
¥ ¦
$num
§ ©
,
© ª
$num
« ­
,
­ ®
$num
¯ ²
,
² ³
DateTimeKind
´ À
.
À Á
Local
Á Æ
)
Æ Ç
.
Ç È
AddTicks
È Ğ
(
Ğ Ñ
$num
Ñ Ó
)
Ó Ô
}
Õ Ö
,
Ö ×
{ 
new 
Guid 
( 
$str E
)E F
,F G
$str	H ‘
,
‘ ’
$str
“ Ã
,
Ã Ä
$str
Å ×
,
× Ø
$str
Ù á
,
á â
new
ã æ
DateTime
ç ï
(
ï ğ
$num
ğ ô
,
ô õ
$num
ö ÷
,
÷ ø
$num
ù ú
,
ú û
$num
ü ş
,
ş ÿ
$num
€ ‚
,
‚ ƒ
$num
„ †
,
† ‡
$num
ˆ ‹
,
‹ Œ
DateTimeKind
 ™
.
™ š
Local
š Ÿ
)
Ÿ  
.
  ¡
AddTicks
¡ ©
(
© ª
$num
ª ¬
)
¬ ­
,
­ ®
$str
¯ à
,
à á
$str
â ë
,
ë ì
$str
í †
,
† ‡
$str
ˆ ¦
,
¦ §
$str
¨ ¯
,
¯ °
$str
± Í
,
Í Î
$str
Ï Ü
,
Ü İ
$num
Ş ß
,
ß à
$str
á ÿ
,
ÿ €
$str
 ¥
,
¥ ¦
$str
§ ®
,
® ¯
new
° ³
DateTime
´ ¼
(
¼ ½
$num
½ Á
,
Á Â
$num
Ã Ä
,
Ä Å
$num
Æ Ç
,
Ç È
$num
É Ë
,
Ë Ì
$num
Í Ï
,
Ï Ğ
$num
Ñ Ó
,
Ó Ô
$num
Õ Ø
,
Ø Ù
DateTimeKind
Ú æ
.
æ ç
Local
ç ì
)
ì í
.
í î
AddTicks
î ö
(
ö ÷
$num
÷ ù
)
ù ú
}
û ü
,
ü ı
{ 
new 
Guid 
( 
$str E
)E F
,F G
$strH s
,s t
$str	u ™
,
™ š
$str
› ¥
,
¥ ¦
$str
§ ¯
,
¯ °
new
± ´
DateTime
µ ½
(
½ ¾
$num
¾ Â
,
Â Ã
$num
Ä Å
,
Å Æ
$num
Ç È
,
È É
$num
Ê Ì
,
Ì Í
$num
Î Ğ
,
Ğ Ñ
$num
Ò Ô
,
Ô Õ
$num
Ö Ù
,
Ù Ú
DateTimeKind
Û ç
.
ç è
Local
è í
)
í î
.
î ï
AddTicks
ï ÷
(
÷ ø
$num
ø ú
)
ú û
,
û ü
$str
ı Ã
,
Ã Ä
$str
Å Î
,
Î Ï
$str
Ğ é
,
é ê
$str
ë ˜
,
˜ ™
$str
š ¦
,
¦ §
$str
¨ Ä
,
Ä Å
$str
Æ Ó
,
Ó Ô
$num
Õ Ö
,
Ö ×
$str
Ø …
,
… †
$str
‡ §
,
§ ¨
$str
© °
,
° ±
new
² µ
DateTime
¶ ¾
(
¾ ¿
$num
¿ Ã
,
Ã Ä
$num
Å Æ
,
Æ Ç
$num
È É
,
É Ê
$num
Ë Í
,
Í Î
$num
Ï Ñ
,
Ñ Ò
$num
Ó Õ
,
Õ Ö
$num
× Ú
,
Ú Û
DateTimeKind
Ü è
.
è é
Local
é î
)
î ï
.
ï ğ
AddTicks
ğ ø
(
ø ù
$num
ù û
)
û ü
}
ı ş
,
ş ÿ
{   
new   
Guid   
(   
$str   E
)  E F
,  F G
$str	  H ¾
,
  ¾ ¿
$str
  À 
,
   Ÿ
$str
    ª
,
  ª «
$str
  ¬ ´
,
  ´ µ
new
  ¶ ¹
DateTime
  º Â
(
  Â Ã
$num
  Ã Ç
,
  Ç È
$num
  É Ê
,
  Ê Ë
$num
  Ì Í
,
  Í Î
$num
  Ï Ñ
,
  Ñ Ò
$num
  Ó Õ
,
  Õ Ö
$num
  × Ù
,
  Ù Ú
$num
  Û Ş
,
  Ş ß
DateTimeKind
  à ì
.
  ì í
Local
  í ò
)
  ò ó
.
  ó ô
AddTicks
  ô ü
(
  ü ı
$num
  ı ÿ
)
  ÿ €
,
  € 
$str
  ‚ Æ
,
  Æ Ç
$str
  È Ñ
,
  Ñ Ò
$str
  Ó ø
,
  ø ù
$str
  ú  
,
    ¡
$str
  ¢ ¬
,
  ¬ ­
$str
  ® Ê
,
  Ê Ë
$str
  Ì Ù
,
  Ù Ú
$num
  Û Ü
,
  Ü İ
$str
  Ş ó
,
  ó ô
$str
  õ Š
,
  Š ‹
$str
  Œ “
,
  “ ”
new
  • ˜
DateTime
  ™ ¡
(
  ¡ ¢
$num
  ¢ ¦
,
  ¦ §
$num
  ¨ ©
,
  © ª
$num
  « ¬
,
  ¬ ­
$num
  ® °
,
  ° ±
$num
  ² ´
,
  ´ µ
$num
  ¶ ¸
,
  ¸ ¹
$num
  º ½
,
  ½ ¾
DateTimeKind
  ¿ Ë
.
  Ë Ì
Local
  Ì Ñ
)
  Ñ Ò
.
  Ò Ó
AddTicks
  Ó Û
(
  Û Ü
$num
  Ü Ş
)
  Ş ß
}
  à á
,
  á â
{!! 
new!! 
Guid!! 
(!! 
$str!! E
)!!E F
,!!F G
$str	!!H 
,
!! 
$str
!!‘ Á
,
!!Á Â
$str
!!Ã Ú
,
!!Ú Û
$str
!!Ü ä
,
!!ä å
new
!!æ é
DateTime
!!ê ò
(
!!ò ó
$num
!!ó ÷
,
!!÷ ø
$num
!!ù ú
,
!!ú û
$num
!!ü ı
,
!!ı ş
$num
!!ÿ 
,
!! ‚
$num
!!ƒ …
,
!!… †
$num
!!‡ ‰
,
!!‰ Š
$num
!!‹ 
,
!! 
DateTimeKind
!! œ
.
!!œ 
Local
!! ¢
)
!!¢ £
.
!!£ ¤
AddTicks
!!¤ ¬
(
!!¬ ­
$num
!!­ ¯
)
!!¯ °
,
!!° ±
$str
!!² ã
,
!!ã ä
$str
!!å î
,
!!î ï
$str
!!ğ ‰
,
!!‰ Š
$str
!!‹ ±
,
!!± ²
$str
!!³ ¿
,
!!¿ À
$str
!!Á İ
,
!!İ Ş
$str
!!ß ì
,
!!ì í
$num
!!î ï
,
!!ï ğ
$str
!!ñ ‘
,
!!‘ ’
$str
!!“ «
,
!!« ¬
$str
!!­ ´
,
!!´ µ
new
!!¶ ¹
DateTime
!!º Â
(
!!Â Ã
$num
!!Ã Ç
,
!!Ç È
$num
!!É Ê
,
!!Ê Ë
$num
!!Ì Í
,
!!Í Î
$num
!!Ï Ñ
,
!!Ñ Ò
$num
!!Ó Õ
,
!!Õ Ö
$num
!!× Ù
,
!!Ù Ú
$num
!!Û Ş
,
!!Ş ß
DateTimeKind
!!à ì
.
!!ì í
Local
!!í ò
)
!!ò ó
.
!!ó ô
AddTicks
!!ô ü
(
!!ü ı
$num
!!ı ÿ
)
!!ÿ €
}
!! ‚
,
!!‚ ƒ
{"" 
new"" 
Guid"" 
("" 
$str"" E
)""E F
,""F G
$str	""H 
,
"" 
$str
""‘ º
,
""º »
$str
""¼ Ê
,
""Ê Ë
$str
""Ì Ô
,
""Ô Õ
new
""Ö Ù
DateTime
""Ú â
(
""â ã
$num
""ã ç
,
""ç è
$num
""é ê
,
""ê ë
$num
""ì í
,
""í î
$num
""ï ñ
,
""ñ ò
$num
""ó õ
,
""õ ö
$num
""÷ ù
,
""ù ú
$num
""û ş
,
""ş ÿ
DateTimeKind
""€ Œ
.
""Œ 
Local
"" ’
)
""’ “
.
""“ ”
AddTicks
""” œ
(
""œ 
$num
"" Ÿ
)
""Ÿ  
,
""  ¡
$str
""¢ Ó
,
""Ó Ô
$str
""Õ Ş
,
""Ş ß
$str
""à ì
,
""ì í
$str
""î ş
,
""ş ÿ
$str
""€ Š
,
""Š ‹
$str
""Œ ¢
,
""¢ £
$str
""¤ °
,
""° ±
$num
""² ³
,
""³ ´
$str
""µ Æ
,
""Æ Ç
$str
""È İ
,
""İ Ş
$str
""ß æ
,
""æ ç
new
""è ë
DateTime
""ì ô
(
""ô õ
$num
""õ ù
,
""ù ú
$num
""û ü
,
""ü ı
$num
""ş ÿ
,
""ÿ €
$num
"" ƒ
,
""ƒ „
$num
""… ‡
,
""‡ ˆ
$num
""‰ ‹
,
""‹ Œ
$num
"" 
,
"" ‘
DateTimeKind
""’ 
.
"" Ÿ
Local
""Ÿ ¤
)
""¤ ¥
.
""¥ ¦
AddTicks
""¦ ®
(
""® ¯
$num
""¯ ±
)
""± ²
}
""³ ´
,
""´ µ
{## 
new## 
Guid## 
(## 
$str## E
)##E F
,##F G
$str	##H °
,
##° ±
$str
##² â
,
##â ã
$str
##ä í
,
##í î
$str
##ï ÷
,
##÷ ø
new
##ù ü
DateTime
##ı …
(
##… †
$num
##† Š
,
##Š ‹
$num
##Œ 
,
## 
$num
## 
,
## ‘
$num
##’ ”
,
##” •
$num
##– ˜
,
##˜ ™
$num
##š œ
,
##œ 
$num
## ¡
,
##¡ ¢
DateTimeKind
##£ ¯
.
##¯ °
Local
##° µ
)
##µ ¶
.
##¶ ·
AddTicks
##· ¿
(
##¿ À
$num
##À Ä
)
##Ä Å
,
##Å Æ
$str
##Ç ø
,
##ø ù
$str
##ú ƒ
,
##ƒ „
$str
##… 
,
## Ÿ
$str
##  »
,
##» ¼
$str
##½ Ç
,
##Ç È
$str
##É å
,
##å æ
$str
##ç ô
,
##ô õ
$num
##ö ÷
,
##÷ ø
$str
##ù 
,
## 
$str
## 
,
## 
$str
##Ÿ ¦
,
##¦ §
new
##¨ «
DateTime
##¬ ´
(
##´ µ
$num
##µ ¹
,
##¹ º
$num
##» ¼
,
##¼ ½
$num
##¾ ¿
,
##¿ À
$num
##Á Ã
,
##Ã Ä
$num
##Å Ç
,
##Ç È
$num
##É Ë
,
##Ë Ì
$num
##Í Ğ
,
##Ğ Ñ
DateTimeKind
##Ò Ş
.
##Ş ß
Local
##ß ä
)
##ä å
.
##å æ
AddTicks
##æ î
(
##î ï
$num
##ï ó
)
##ó ô
}
##õ ö
,
##ö ÷
{$$ 
new$$ 
Guid$$ 
($$ 
$str$$ E
)$$E F
,$$F G
$str	$$H 
,
$$ 
$str
$$‘ Á
,
$$Á Â
$str
$$Ã Ú
,
$$Ú Û
$str
$$Ü ä
,
$$ä å
new
$$æ é
DateTime
$$ê ò
(
$$ò ó
$num
$$ó ÷
,
$$÷ ø
$num
$$ù ú
,
$$ú û
$num
$$ü ı
,
$$ı ş
$num
$$ÿ 
,
$$ ‚
$num
$$ƒ …
,
$$… †
$num
$$‡ ‰
,
$$‰ Š
$num
$$‹ 
,
$$ 
DateTimeKind
$$ œ
.
$$œ 
Local
$$ ¢
)
$$¢ £
.
$$£ ¤
AddTicks
$$¤ ¬
(
$$¬ ­
$num
$$­ ¯
)
$$¯ °
,
$$° ±
$str
$$² ã
,
$$ã ä
$str
$$å î
,
$$î ï
$str
$$ğ ‰
,
$$‰ Š
$str
$$‹ ­
,
$$­ ®
$str
$$¯ »
,
$$» ¼
$str
$$½ Ù
,
$$Ù Ú
$str
$$Û è
,
$$è é
$num
$$ê ë
,
$$ë ì
$str
$$í 
,
$$ 
$str
$$ ¨
,
$$¨ ©
$str
$$ª ±
,
$$± ²
new
$$³ ¶
DateTime
$$· ¿
(
$$¿ À
$num
$$À Ä
,
$$Ä Å
$num
$$Æ Ç
,
$$Ç È
$num
$$É Ê
,
$$Ê Ë
$num
$$Ì Î
,
$$Î Ï
$num
$$Ğ Ò
,
$$Ò Ó
$num
$$Ô Ö
,
$$Ö ×
$num
$$Ø Û
,
$$Û Ü
DateTimeKind
$$İ é
.
$$é ê
Local
$$ê ï
)
$$ï ğ
.
$$ğ ñ
AddTicks
$$ñ ù
(
$$ù ú
$num
$$ú ü
)
$$ü ı
}
$$ş ÿ
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
DateTimeKind	]]x „
.
]]„ …
Utc
]]… ˆ
)
]]ˆ ‰
.
]]‰ Š
AddTicks
]]Š ’
(
]]’ “
$num
]]“ —
)
]]— ˜
,
]]˜ ™
$str
]]š ğ
,
]]ğ ñ
$str
]]ò ˜
}
]]™ š
)
]]š ›
;
]]› œ
}^^ 	
}__ 
}`` ˜$
„D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240701055338_RenameSomePropInCourse.cs
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
DateTimeKind	x „
.
„ …
Utc
… ˆ
)
ˆ ‰
.
‰ Š
AddTicks
Š ’
(
’ “
$num
“ —
)
— ˜
,
˜ ™
$str
š ğ
,
ğ ñ
$str
ò ˜
}
™ š
)
š ›
;
› œ
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
DateTimeKind	22x „
.
22„ …
Utc
22… ˆ
)
22ˆ ‰
.
22‰ Š
AddTicks
22Š ’
(
22’ “
$num
22“ —
)
22— ˜
,
22˜ ™
$str
22š ğ
,
22ğ ñ
$str
22ò ˜
}
22™ š
)
22š ›
;
22› œ
}33 	
}44 
}55 ì§
ŒD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240701054917_ModifiedCourseAndCourseVersion.cs
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
DateTimeKind	JJx „
.
JJ„ …
Utc
JJ… ˆ
)
JJˆ ‰
.
JJ‰ Š
AddTicks
JJŠ ’
(
JJ’ “
$num
JJ“ —
)
JJ— ˜
,
JJ˜ ™
$str
JJš ğ
,
JJğ ñ
$str
JJò ˜
}
JJ™ š
)
JJš ›
;
JJ› œ
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
€€ 
:
€€ 
$str
€€ (
,
€€( )
nullable
 
:
 
true
 
)
 
;
  
migrationBuilder
ƒƒ 
.
ƒƒ 
	AddColumn
ƒƒ &
<
ƒƒ& '
string
ƒƒ' -
>
ƒƒ- .
(
ƒƒ. /
name
„„ 
:
„„ 
$str
„„ $
,
„„$ %
table
…… 
:
…… 
$str
……  
,
……  !
type
†† 
:
†† 
$str
†† %
,
††% &
nullable
‡‡ 
:
‡‡ 
true
‡‡ 
)
‡‡ 
;
‡‡  
migrationBuilder
‰‰ 
.
‰‰ 
	AddColumn
‰‰ &
<
‰‰& '
string
‰‰' -
>
‰‰- .
(
‰‰. /
name
ŠŠ 
:
ŠŠ 
$str
ŠŠ #
,
ŠŠ# $
table
‹‹ 
:
‹‹ 
$str
‹‹  
,
‹‹  !
type
ŒŒ 
:
ŒŒ 
$str
ŒŒ %
,
ŒŒ% &
nullable
 
:
 
true
 
)
 
;
  
migrationBuilder
 
.
 
	AddColumn
 &
<
& '
int
' *
>
* +
(
+ ,
name
 
:
 
$str
 $
,
$ %
table
‘‘ 
:
‘‘ 
$str
‘‘  
,
‘‘  !
type
’’ 
:
’’ 
$str
’’ 
,
’’ 
nullable
““ 
:
““ 
true
““ 
)
““ 
;
““  
migrationBuilder
•• 
.
•• 
	AddColumn
•• &
<
••& '
double
••' -
>
••- .
(
••. /
name
–– 
:
–– 
$str
––  
,
––  !
table
—— 
:
—— 
$str
——  
,
——  !
type
˜˜ 
:
˜˜ 
$str
˜˜ 
,
˜˜ 
nullable
™™ 
:
™™ 
true
™™ 
)
™™ 
;
™™  
migrationBuilder
›› 
.
›› 
	AddColumn
›› &
<
››& '
double
››' -
>
››- .
(
››. /
name
œœ 
:
œœ 
$str
œœ 
,
œœ 
table
 
:
 
$str
  
,
  !
type
 
:
 
$str
 
,
 
nullable
ŸŸ 
:
ŸŸ 
true
ŸŸ 
)
ŸŸ 
;
ŸŸ  
migrationBuilder
¡¡ 
.
¡¡ 
	AddColumn
¡¡ &
<
¡¡& '
string
¡¡' -
>
¡¡- .
(
¡¡. /
name
¢¢ 
:
¢¢ 
$str
¢¢ 
,
¢¢ 
table
££ 
:
££ 
$str
££  
,
££  !
type
¤¤ 
:
¤¤ 
$str
¤¤ %
,
¤¤% &
nullable
¥¥ 
:
¥¥ 
true
¥¥ 
)
¥¥ 
;
¥¥  
migrationBuilder
§§ 
.
§§ 
CreateTable
§§ (
(
§§( )
name
¨¨ 
:
¨¨ 
$str
¨¨ &
,
¨¨& '
columns
©© 
:
©© 
table
©© 
=>
©© !
new
©©" %
{
ªª 
Id
«« 
=
«« 
table
«« 
.
«« 
Column
«« %
<
««% &
Guid
««& *
>
««* +
(
««+ ,
type
««, 0
:
««0 1
$str
««2 D
,
««D E
nullable
««F N
:
««N O
false
««P U
)
««U V
,
««V W
CourseId
¬¬ 
=
¬¬ 
table
¬¬ $
.
¬¬$ %
Column
¬¬% +
<
¬¬+ ,
Guid
¬¬, 0
>
¬¬0 1
(
¬¬1 2
type
¬¬2 6
:
¬¬6 7
$str
¬¬8 J
,
¬¬J K
nullable
¬¬L T
:
¬¬T U
false
¬¬V [
)
¬¬[ \
,
¬¬\ ]
Description
­­ 
=
­­  !
table
­­" '
.
­­' (
Column
­­( .
<
­­. /
string
­­/ 5
>
­­5 6
(
­­6 7
type
­­7 ;
:
­­; <
$str
­­= L
,
­­L M
nullable
­­N V
:
­­V W
false
­­X ]
)
­­] ^
,
­­^ _
Title
®® 
=
®® 
table
®® !
.
®®! "
Column
®®" (
<
®®( )
string
®®) /
>
®®/ 0
(
®®0 1
type
®®1 5
:
®®5 6
$str
®®7 F
,
®®F G
nullable
®®H P
:
®®P Q
false
®®R W
)
®®W X
}
¯¯ 
,
¯¯ 
constraints
°° 
:
°° 
table
°° "
=>
°°# %
{
±± 
table
²² 
.
²² 

PrimaryKey
²² $
(
²²$ %
$str
²²% 8
,
²²8 9
x
²²: ;
=>
²²< >
x
²²? @
.
²²@ A
Id
²²A C
)
²²C D
;
²²D E
table
³³ 
.
³³ 

ForeignKey
³³ $
(
³³$ %
name
´´ 
:
´´ 
$str
´´ B
,
´´B C
column
µµ 
:
µµ 
x
µµ  !
=>
µµ" $
x
µµ% &
.
µµ& '
CourseId
µµ' /
,
µµ/ 0
principalTable
¶¶ &
:
¶¶& '
$str
¶¶( 1
,
¶¶1 2
principalColumn
·· '
:
··' (
$str
··) -
,
··- .
onDelete
¸¸  
:
¸¸  !
ReferentialAction
¸¸" 3
.
¸¸3 4
Cascade
¸¸4 ;
)
¸¸; <
;
¸¸< =
}
¹¹ 
)
¹¹ 
;
¹¹ 
migrationBuilder
»» 
.
»» 
CreateTable
»» (
(
»»( )
name
¼¼ 
:
¼¼ 
$str
¼¼ &
,
¼¼& '
columns
½½ 
:
½½ 
table
½½ 
=>
½½ !
new
½½" %
{
¾¾ 
Id
¿¿ 
=
¿¿ 
table
¿¿ 
.
¿¿ 
Column
¿¿ %
<
¿¿% &
Guid
¿¿& *
>
¿¿* +
(
¿¿+ ,
type
¿¿, 0
:
¿¿0 1
$str
¿¿2 D
,
¿¿D E
nullable
¿¿F N
:
¿¿N O
false
¿¿P U
)
¿¿U V
,
¿¿V W
CourseSectionId
ÀÀ #
=
ÀÀ$ %
table
ÀÀ& +
.
ÀÀ+ ,
Column
ÀÀ, 2
<
ÀÀ2 3
Guid
ÀÀ3 7
>
ÀÀ7 8
(
ÀÀ8 9
type
ÀÀ9 =
:
ÀÀ= >
$str
ÀÀ? Q
,
ÀÀQ R
nullable
ÀÀS [
:
ÀÀ[ \
false
ÀÀ] b
)
ÀÀb c
,
ÀÀc d
DocsUrl
ÁÁ 
=
ÁÁ 
table
ÁÁ #
.
ÁÁ# $
Column
ÁÁ$ *
<
ÁÁ* +
string
ÁÁ+ 1
>
ÁÁ1 2
(
ÁÁ2 3
type
ÁÁ3 7
:
ÁÁ7 8
$str
ÁÁ9 H
,
ÁÁH I
nullable
ÁÁJ R
:
ÁÁR S
true
ÁÁT X
)
ÁÁX Y
,
ÁÁY Z
Name
ÂÂ 
=
ÂÂ 
table
ÂÂ  
.
ÂÂ  !
Column
ÂÂ! '
<
ÂÂ' (
string
ÂÂ( .
>
ÂÂ. /
(
ÂÂ/ 0
type
ÂÂ0 4
:
ÂÂ4 5
$str
ÂÂ6 E
,
ÂÂE F
nullable
ÂÂG O
:
ÂÂO P
false
ÂÂQ V
)
ÂÂV W
,
ÂÂW X
SlideUrl
ÃÃ 
=
ÃÃ 
table
ÃÃ $
.
ÃÃ$ %
Column
ÃÃ% +
<
ÃÃ+ ,
string
ÃÃ, 2
>
ÃÃ2 3
(
ÃÃ3 4
type
ÃÃ4 8
:
ÃÃ8 9
$str
ÃÃ: I
,
ÃÃI J
nullable
ÃÃK S
:
ÃÃS T
false
ÃÃU Z
)
ÃÃZ [
,
ÃÃ[ \
Type
ÄÄ 
=
ÄÄ 
table
ÄÄ  
.
ÄÄ  !
Column
ÄÄ! '
<
ÄÄ' (
int
ÄÄ( +
>
ÄÄ+ ,
(
ÄÄ, -
type
ÄÄ- 1
:
ÄÄ1 2
$str
ÄÄ3 8
,
ÄÄ8 9
nullable
ÄÄ: B
:
ÄÄB C
true
ÄÄD H
)
ÄÄH I
,
ÄÄI J
VideoUrl
ÅÅ 
=
ÅÅ 
table
ÅÅ $
.
ÅÅ$ %
Column
ÅÅ% +
<
ÅÅ+ ,
string
ÅÅ, 2
>
ÅÅ2 3
(
ÅÅ3 4
type
ÅÅ4 8
:
ÅÅ8 9
$str
ÅÅ: I
,
ÅÅI J
nullable
ÅÅK S
:
ÅÅS T
false
ÅÅU Z
)
ÅÅZ [
}
ÆÆ 
,
ÆÆ 
constraints
ÇÇ 
:
ÇÇ 
table
ÇÇ "
=>
ÇÇ# %
{
ÈÈ 
table
ÉÉ 
.
ÉÉ 

PrimaryKey
ÉÉ $
(
ÉÉ$ %
$str
ÉÉ% 8
,
ÉÉ8 9
x
ÉÉ: ;
=>
ÉÉ< >
x
ÉÉ? @
.
ÉÉ@ A
Id
ÉÉA C
)
ÉÉC D
;
ÉÉD E
table
ÊÊ 
.
ÊÊ 

ForeignKey
ÊÊ $
(
ÊÊ$ %
name
ËË 
:
ËË 
$str
ËË P
,
ËËP Q
column
ÌÌ 
:
ÌÌ 
x
ÌÌ  !
=>
ÌÌ" $
x
ÌÌ% &
.
ÌÌ& '
CourseSectionId
ÌÌ' 6
,
ÌÌ6 7
principalTable
ÍÍ &
:
ÍÍ& '
$str
ÍÍ( 8
,
ÍÍ8 9
principalColumn
ÎÎ '
:
ÎÎ' (
$str
ÎÎ) -
,
ÎÎ- .
onDelete
ÏÏ  
:
ÏÏ  !
ReferentialAction
ÏÏ" 3
.
ÏÏ3 4
Cascade
ÏÏ4 ;
)
ÏÏ; <
;
ÏÏ< =
}
ĞĞ 
)
ĞĞ 
;
ĞĞ 
migrationBuilder
ÒÒ 
.
ÒÒ 

UpdateData
ÒÒ '
(
ÒÒ' (
table
ÓÓ 
:
ÓÓ 
$str
ÓÓ $
,
ÓÓ$ %
	keyColumn
ÔÔ 
:
ÔÔ 
$str
ÔÔ 
,
ÔÔ  
keyValue
ÕÕ 
:
ÕÕ 
$str
ÕÕ +
,
ÕÕ+ ,
columns
ÖÖ 
:
ÖÖ 
new
ÖÖ 
[
ÖÖ 
]
ÖÖ 
{
ÖÖ  
$str
ÖÖ! 3
,
ÖÖ3 4
$str
ÖÖ5 A
,
ÖÖA B
$str
ÖÖC Q
,
ÖÖQ R
$str
ÖÖS b
}
ÖÖc d
,
ÖÖd e
values
×× 
:
×× 
new
×× 
object
×× "
[
××" #
]
××# $
{
××% &
$str
××' M
,
××M N
new
××O R
DateTime
××S [
(
××[ \
$num
××\ `
,
××` a
$num
××b c
,
××c d
$num
××e f
,
××f g
$num
××h i
,
××i j
$num
××k m
,
××m n
$num
××o q
,
××q r
$num
××s v
,
××v w
DateTimeKind××x „
.××„ …
Utc××… ˆ
)××ˆ ‰
.××‰ Š
AddTicks××Š ’
(××’ “
$num××“ —
)××— ˜
,××˜ ™
$str××š ğ
,××ğ ñ
$str××ò ˜
}××™ š
)××š ›
;××› œ
migrationBuilder
ÙÙ 
.
ÙÙ 
CreateIndex
ÙÙ (
(
ÙÙ( )
name
ÚÚ 
:
ÚÚ 
$str
ÚÚ -
,
ÚÚ- .
table
ÛÛ 
:
ÛÛ 
$str
ÛÛ  
,
ÛÛ  !
column
ÜÜ 
:
ÜÜ 
$str
ÜÜ $
)
ÜÜ$ %
;
ÜÜ% &
migrationBuilder
ŞŞ 
.
ŞŞ 
CreateIndex
ŞŞ (
(
ŞŞ( )
name
ßß 
:
ßß 
$str
ßß *
,
ßß* +
table
àà 
:
àà 
$str
àà  
,
àà  !
column
áá 
:
áá 
$str
áá !
)
áá! "
;
áá" #
migrationBuilder
ãã 
.
ãã 
CreateIndex
ãã (
(
ãã( )
name
ää 
:
ää 
$str
ää 2
,
ää2 3
table
åå 
:
åå 
$str
åå '
,
åå' (
column
ææ 
:
ææ 
$str
ææ "
)
ææ" #
;
ææ# $
migrationBuilder
èè 
.
èè 
CreateIndex
èè (
(
èè( )
name
éé 
:
éé 
$str
éé 9
,
éé9 :
table
êê 
:
êê 
$str
êê '
,
êê' (
column
ëë 
:
ëë 
$str
ëë )
)
ëë) *
;
ëë* +
migrationBuilder
íí 
.
íí 
AddForeignKey
íí *
(
íí* +
name
îî 
:
îî 
$str
îî 8
,
îî8 9
table
ïï 
:
ïï 
$str
ïï  
,
ïï  !
column
ğğ 
:
ğğ 
$str
ğğ $
,
ğğ$ %
principalTable
ññ 
:
ññ 
$str
ññ  ,
,
ññ, -
principalColumn
òò 
:
òò  
$str
òò! %
)
òò% &
;
òò& '
migrationBuilder
ôô 
.
ôô 
AddForeignKey
ôô *
(
ôô* +
name
õõ 
:
õõ 
$str
õõ 1
,
õõ1 2
table
öö 
:
öö 
$str
öö  
,
öö  !
column
÷÷ 
:
÷÷ 
$str
÷÷ !
,
÷÷! "
principalTable
øø 
:
øø 
$str
øø  (
,
øø( )
principalColumn
ùù 
:
ùù  
$str
ùù! %
)
ùù% &
;
ùù& '
}
úú 	
}
ûû 
}üü µ
ˆD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240701051059_AddMoreUrlToSectionDetails.cs
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
}== Ÿ9
‰D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240629022632_AddMoreColumnForCourseTable.cs
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
DateTimeKind	77y …
.
77… †
Utc
77† ‰
)
77‰ Š
.
77Š ‹
AddTicks
77‹ “
(
77“ ”
$num
77” ˜
)
77˜ ™
,
77™ š
$str
77› ñ
,
77ñ ò
$str
77ó ™
}
77š ›
)
77› œ
;
77œ 
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
DateTimeKind	ZZz †
.
ZZ† ‡
Utc
ZZ‡ Š
)
ZZŠ ‹
.
ZZ‹ Œ
AddTicks
ZZŒ ”
(
ZZ” •
$num
ZZ• ™
)
ZZ™ š
,
ZZš ›
$str
ZZœ ò
,
ZZò ó
$str
ZZô š
}
ZZ› œ
)
ZZœ 
;
ZZ 
}[[ 	
}\\ 
}]] ‰&
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628165735_AllowNullForCourseVerionInstructor.cs
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
DateTimeKind	z †
.
† ‡
Utc
‡ Š
)
Š ‹
.
‹ Œ
AddTicks
Œ ”
(
” •
$num
• ™
)
™ š
,
š ›
$str
œ ò
,
ò ó
$str
ô š
}
› œ
)
œ 
;
 
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
DateTimeKind	00z †
.
00† ‡
Utc
00‡ Š
)
00Š ‹
.
00‹ Œ
AddTicks
00Œ ”
(
00” •
$num
00• ™
)
00™ š
,
00š ›
$str
00œ ò
,
00ò ó
$str
00ô š
}
00› œ
)
00œ 
;
00 
}11 	
}22 
}33  «
…D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628164825_AllowNullForCourseProps.cs
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
€€ 
.
€€ 
AddForeignKey
€€ *
(
€€* +
name
 
:
 
$str
 1
,
1 2
table
‚‚ 
:
‚‚ 
$str
‚‚  
,
‚‚  !
column
ƒƒ 
:
ƒƒ 
$str
ƒƒ !
,
ƒƒ! "
principalTable
„„ 
:
„„ 
$str
„„  (
,
„„( )
principalColumn
…… 
:
……  
$str
……! %
)
……% &
;
……& '
}
†† 	
	protected
‰‰ 
override
‰‰ 
void
‰‰ 
Down
‰‰  $
(
‰‰$ %
MigrationBuilder
‰‰% 5
migrationBuilder
‰‰6 F
)
‰‰F G
{
ŠŠ 	
migrationBuilder
‹‹ 
.
‹‹ 
DropForeignKey
‹‹ +
(
‹‹+ ,
name
ŒŒ 
:
ŒŒ 
$str
ŒŒ 8
,
ŒŒ8 9
table
 
:
 
$str
  
)
  !
;
! "
migrationBuilder
 
.
 
DropForeignKey
 +
(
+ ,
name
 
:
 
$str
 ;
,
; <
table
‘‘ 
:
‘‘ 
$str
‘‘  
)
‘‘  !
;
‘‘! "
migrationBuilder
““ 
.
““ 
DropForeignKey
““ +
(
““+ ,
name
”” 
:
”” 
$str
”” 1
,
””1 2
table
•• 
:
•• 
$str
••  
)
••  !
;
••! "
migrationBuilder
—— 
.
—— 
AlterColumn
—— (
<
——( )
int
——) ,
>
——, -
(
——- .
name
˜˜ 
:
˜˜ 
$str
˜˜ 
,
˜˜  
table
™™ 
:
™™ 
$str
™™  
,
™™  !
type
šš 
:
šš 
$str
šš 
,
šš 
nullable
›› 
:
›› 
false
›› 
,
››  
defaultValue
œœ 
:
œœ 
$num
œœ 
,
œœ  

oldClrType
 
:
 
typeof
 "
(
" #
int
# &
)
& '
,
' (
oldType
 
:
 
$str
 
,
 
oldNullable
ŸŸ 
:
ŸŸ 
true
ŸŸ !
)
ŸŸ! "
;
ŸŸ" #
migrationBuilder
¡¡ 
.
¡¡ 
AlterColumn
¡¡ (
<
¡¡( )
float
¡¡) .
>
¡¡. /
(
¡¡/ 0
name
¢¢ 
:
¢¢ 
$str
¢¢ !
,
¢¢! "
table
££ 
:
££ 
$str
££  
,
££  !
type
¤¤ 
:
¤¤ 
$str
¤¤ 
,
¤¤ 
nullable
¥¥ 
:
¥¥ 
false
¥¥ 
,
¥¥  
defaultValue
¦¦ 
:
¦¦ 
$num
¦¦  
,
¦¦  !

oldClrType
§§ 
:
§§ 
typeof
§§ "
(
§§" #
float
§§# (
)
§§( )
,
§§) *
oldType
¨¨ 
:
¨¨ 
$str
¨¨ 
,
¨¨  
oldNullable
©© 
:
©© 
true
©© !
)
©©! "
;
©©" #
migrationBuilder
«« 
.
«« 
AlterColumn
«« (
<
««( )
string
««) /
>
««/ 0
(
««0 1
name
¬¬ 
:
¬¬ 
$str
¬¬ 
,
¬¬ 
table
­­ 
:
­­ 
$str
­­  
,
­­  !
type
®® 
:
®® 
$str
®® %
,
®®% &
nullable
¯¯ 
:
¯¯ 
false
¯¯ 
,
¯¯  
defaultValue
°° 
:
°° 
$str
°°  
,
°°  !

oldClrType
±± 
:
±± 
typeof
±± "
(
±±" #
string
±±# )
)
±±) *
,
±±* +
oldType
²² 
:
²² 
$str
²² (
,
²²( )
oldNullable
³³ 
:
³³ 
true
³³ !
)
³³! "
;
³³" #
migrationBuilder
µµ 
.
µµ 
AlterColumn
µµ (
<
µµ( )
int
µµ) ,
>
µµ, -
(
µµ- .
name
¶¶ 
:
¶¶ 
$str
¶¶ #
,
¶¶# $
table
·· 
:
·· 
$str
··  
,
··  !
type
¸¸ 
:
¸¸ 
$str
¸¸ 
,
¸¸ 
nullable
¹¹ 
:
¹¹ 
false
¹¹ 
,
¹¹  
defaultValue
ºº 
:
ºº 
$num
ºº 
,
ºº  

oldClrType
»» 
:
»» 
typeof
»» "
(
»»" #
int
»»# &
)
»»& '
,
»»' (
oldType
¼¼ 
:
¼¼ 
$str
¼¼ 
,
¼¼ 
oldNullable
½½ 
:
½½ 
true
½½ !
)
½½! "
;
½½" #
migrationBuilder
¿¿ 
.
¿¿ 
AlterColumn
¿¿ (
<
¿¿( )
double
¿¿) /
>
¿¿/ 0
(
¿¿0 1
name
ÀÀ 
:
ÀÀ 
$str
ÀÀ 
,
ÀÀ 
table
ÁÁ 
:
ÁÁ 
$str
ÁÁ  
,
ÁÁ  !
type
ÂÂ 
:
ÂÂ 
$str
ÂÂ 
,
ÂÂ 
nullable
ÃÃ 
:
ÃÃ 
false
ÃÃ 
,
ÃÃ  
defaultValue
ÄÄ 
:
ÄÄ 
$num
ÄÄ !
,
ÄÄ! "

oldClrType
ÅÅ 
:
ÅÅ 
typeof
ÅÅ "
(
ÅÅ" #
double
ÅÅ# )
)
ÅÅ) *
,
ÅÅ* +
oldType
ÆÆ 
:
ÆÆ 
$str
ÆÆ  
,
ÆÆ  !
oldNullable
ÇÇ 
:
ÇÇ 
true
ÇÇ !
)
ÇÇ! "
;
ÇÇ" #
migrationBuilder
ÉÉ 
.
ÉÉ 
AlterColumn
ÉÉ (
<
ÉÉ( )
Guid
ÉÉ) -
>
ÉÉ- .
(
ÉÉ. /
name
ÊÊ 
:
ÊÊ 
$str
ÊÊ 
,
ÊÊ  
table
ËË 
:
ËË 
$str
ËË  
,
ËË  !
type
ÌÌ 
:
ÌÌ 
$str
ÌÌ (
,
ÌÌ( )
nullable
ÍÍ 
:
ÍÍ 
false
ÍÍ 
,
ÍÍ  
defaultValue
ÎÎ 
:
ÎÎ 
new
ÎÎ !
Guid
ÎÎ" &
(
ÎÎ& '
$str
ÎÎ' M
)
ÎÎM N
,
ÎÎN O

oldClrType
ÏÏ 
:
ÏÏ 
typeof
ÏÏ "
(
ÏÏ" #
Guid
ÏÏ# '
)
ÏÏ' (
,
ÏÏ( )
oldType
ĞĞ 
:
ĞĞ 
$str
ĞĞ +
,
ĞĞ+ ,
oldNullable
ÑÑ 
:
ÑÑ 
true
ÑÑ !
)
ÑÑ! "
;
ÑÑ" #
migrationBuilder
ÓÓ 
.
ÓÓ 
AlterColumn
ÓÓ (
<
ÓÓ( )
int
ÓÓ) ,
>
ÓÓ, -
(
ÓÓ- .
name
ÔÔ 
:
ÔÔ 
$str
ÔÔ $
,
ÔÔ$ %
table
ÕÕ 
:
ÕÕ 
$str
ÕÕ  
,
ÕÕ  !
type
ÖÖ 
:
ÖÖ 
$str
ÖÖ 
,
ÖÖ 
nullable
×× 
:
×× 
false
×× 
,
××  
defaultValue
ØØ 
:
ØØ 
$num
ØØ 
,
ØØ  

oldClrType
ÙÙ 
:
ÙÙ 
typeof
ÙÙ "
(
ÙÙ" #
int
ÙÙ# &
)
ÙÙ& '
,
ÙÙ' (
oldType
ÚÚ 
:
ÚÚ 
$str
ÚÚ 
,
ÚÚ 
oldNullable
ÛÛ 
:
ÛÛ 
true
ÛÛ !
)
ÛÛ! "
;
ÛÛ" #
migrationBuilder
İİ 
.
İİ 
AlterColumn
İİ (
<
İİ( )
Guid
İİ) -
>
İİ- .
(
İİ. /
name
ŞŞ 
:
ŞŞ 
$str
ŞŞ $
,
ŞŞ$ %
table
ßß 
:
ßß 
$str
ßß  
,
ßß  !
type
àà 
:
àà 
$str
àà (
,
àà( )
nullable
áá 
:
áá 
false
áá 
,
áá  
defaultValue
ââ 
:
ââ 
new
ââ !
Guid
ââ" &
(
ââ& '
$str
ââ' M
)
ââM N
,
ââN O

oldClrType
ãã 
:
ãã 
typeof
ãã "
(
ãã" #
Guid
ãã# '
)
ãã' (
,
ãã( )
oldType
ää 
:
ää 
$str
ää +
,
ää+ ,
oldNullable
åå 
:
åå 
true
åå !
)
åå! "
;
åå" #
migrationBuilder
çç 
.
çç 
AlterColumn
çç (
<
çç( )
string
çç) /
>
çç/ 0
(
çç0 1
name
èè 
:
èè 
$str
èè #
,
èè# $
table
éé 
:
éé 
$str
éé  
,
éé  !
type
êê 
:
êê 
$str
êê %
,
êê% &
nullable
ëë 
:
ëë 
false
ëë 
,
ëë  
defaultValue
ìì 
:
ìì 
$str
ìì  
,
ìì  !

oldClrType
íí 
:
íí 
typeof
íí "
(
íí" #
string
íí# )
)
íí) *
,
íí* +
oldType
îî 
:
îî 
$str
îî (
,
îî( )
oldNullable
ïï 
:
ïï 
true
ïï !
)
ïï! "
;
ïï" #
migrationBuilder
ññ 
.
ññ 
AlterColumn
ññ (
<
ññ( )
string
ññ) /
>
ññ/ 0
(
ññ0 1
name
òò 
:
òò 
$str
òò 
,
òò 
table
óó 
:
óó 
$str
óó  
,
óó  !
type
ôô 
:
ôô 
$str
ôô %
,
ôô% &
nullable
õõ 
:
õõ 
false
õõ 
,
õõ  
defaultValue
öö 
:
öö 
$str
öö  
,
öö  !

oldClrType
÷÷ 
:
÷÷ 
typeof
÷÷ "
(
÷÷" #
string
÷÷# )
)
÷÷) *
,
÷÷* +
oldType
øø 
:
øø 
$str
øø (
,
øø( )
oldNullable
ùù 
:
ùù 
true
ùù !
)
ùù! "
;
ùù" #
migrationBuilder
ûû 
.
ûû 
AlterColumn
ûû (
<
ûû( )
Guid
ûû) -
>
ûû- .
(
ûû. /
name
üü 
:
üü 
$str
üü "
,
üü" #
table
ıı 
:
ıı 
$str
ıı  
,
ıı  !
type
şş 
:
şş 
$str
şş (
,
şş( )
nullable
ÿÿ 
:
ÿÿ 
false
ÿÿ 
,
ÿÿ  
defaultValue
€€ 
:
€€ 
new
€€ !
Guid
€€" &
(
€€& '
$str
€€' M
)
€€M N
,
€€N O

oldClrType
 
:
 
typeof
 "
(
" #
Guid
# '
)
' (
,
( )
oldType
‚‚ 
:
‚‚ 
$str
‚‚ +
,
‚‚+ ,
oldNullable
ƒƒ 
:
ƒƒ 
true
ƒƒ !
)
ƒƒ! "
;
ƒƒ" #
migrationBuilder
…… 
.
…… 
AddForeignKey
…… *
(
……* +
name
†† 
:
†† 
$str
†† 8
,
††8 9
table
‡‡ 
:
‡‡ 
$str
‡‡  
,
‡‡  !
column
ˆˆ 
:
ˆˆ 
$str
ˆˆ $
,
ˆˆ$ %
principalTable
‰‰ 
:
‰‰ 
$str
‰‰  ,
,
‰‰, -
principalColumn
ŠŠ 
:
ŠŠ  
$str
ŠŠ! %
,
ŠŠ% &
onDelete
‹‹ 
:
‹‹ 
ReferentialAction
‹‹ +
.
‹‹+ ,
Cascade
‹‹, 3
)
‹‹3 4
;
‹‹4 5
migrationBuilder
 
.
 
AddForeignKey
 *
(
* +
name
 
:
 
$str
 ;
,
; <
table
 
:
 
$str
  
,
  !
column
 
:
 
$str
 &
,
& '
principalTable
‘‘ 
:
‘‘ 
$str
‘‘  -
,
‘‘- .
principalColumn
’’ 
:
’’  
$str
’’! /
,
’’/ 0
onDelete
““ 
:
““ 
ReferentialAction
““ +
.
““+ ,
Cascade
““, 3
)
““3 4
;
““4 5
migrationBuilder
•• 
.
•• 
AddForeignKey
•• *
(
••* +
name
–– 
:
–– 
$str
–– 1
,
––1 2
table
—— 
:
—— 
$str
——  
,
——  !
column
˜˜ 
:
˜˜ 
$str
˜˜ !
,
˜˜! "
principalTable
™™ 
:
™™ 
$str
™™  (
,
™™( )
principalColumn
šš 
:
šš  
$str
šš! %
,
šš% &
onDelete
›› 
:
›› 
ReferentialAction
›› +
.
››+ ,
Cascade
››, 3
)
››3 4
;
››4 5
}
œœ 	
}
 
} ˜
‰D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628164354_RenameColumnInCourseVersion.cs
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
}== ÿQ
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628080934_RemoveStatusTableAndSomeForeignkey.cs
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
€€ 
:
€€ 
$str
€€ /
,
€€/ 0
column
 
:
 
$str
 *
,
* +
principalTable
‚‚ 
:
‚‚ 
$str
‚‚  0
,
‚‚0 1
principalColumn
ƒƒ 
:
ƒƒ  
$str
ƒƒ! %
,
ƒƒ% &
onDelete
„„ 
:
„„ 
ReferentialAction
„„ +
.
„„+ ,
Cascade
„„, 3
)
„„3 4
;
„„4 5
}
…… 	
}
†† 
}‡‡ õ&
ƒD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628062641_AddCourseCommentTable.cs
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
}44 Á
†D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628061226_AddVersionIntCourseTable.cs
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
} ¦U
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240628035240_AddSateAndPropsForCourseVersion.cs
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
DateTimeKind	KKy …
.
KK… †
Utc
KK† ‰
)
KK‰ Š
.
KKŠ ‹
AddTicks
KK‹ “
(
KK“ ”
$num
KK” ˜
)
KK˜ ™
,
KK™ š
$str
KK› ñ
,
KKñ ò
$str
KKó ™
}
KKš ›
)
KK› œ
;
KKœ 
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
DateTimeKind	rry …
.
rr… †
Utc
rr† ‰
)
rr‰ Š
.
rrŠ ‹
AddTicks
rr‹ “
(
rr“ ”
$num
rr” ˜
)
rr˜ ™
,
rr™ š
$str
rr› ñ
,
rrñ ò
$str
rró ™
}
rrš ›
)
rr› œ
;
rrœ 
}ss 	
}tt 
}uu ßŸ
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
DateTimeKind	wwy …
.
ww… †
Utc
ww† ‰
)
ww‰ Š
.
wwŠ ‹
AddTicks
ww‹ “
(
ww“ ”
$num
ww” ˜
)
ww˜ ™
,
ww™ š
$str
ww› ñ
,
wwñ ò
$str
wwó ™
}
wwš ›
)
ww› œ
;
wwœ 
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
€€ 
:
€€ 
$str
€€ .
,
€€. /
column
 
:
 
$str
 )
)
) *
;
* +
migrationBuilder
ƒƒ 
.
ƒƒ 
CreateIndex
ƒƒ (
(
ƒƒ( )
name
„„ 
:
„„ 
$str
„„ 9
,
„„9 :
table
…… 
:
…… 
$str
…… '
,
……' (
column
†† 
:
†† 
$str
†† )
)
††) *
;
††* +
migrationBuilder
ˆˆ 
.
ˆˆ 
CreateIndex
ˆˆ (
(
ˆˆ( )
name
‰‰ 
:
‰‰ 
$str
‰‰ >
,
‰‰> ?
table
ŠŠ 
:
ŠŠ 
$str
ŠŠ ,
,
ŠŠ, -
column
‹‹ 
:
‹‹ 
$str
‹‹ )
)
‹‹) *
;
‹‹* +
migrationBuilder
 
.
 
CreateIndex
 (
(
( )
name
 
:
 
$str
 H
,
H I
table
 
:
 
$str
 /
,
/ 0
column
 
:
 
$str
 0
)
0 1
;
1 2
migrationBuilder
’’ 
.
’’ 
CreateIndex
’’ (
(
’’( )
name
““ 
:
““ 
$str
““ B
,
““B C
table
”” 
:
”” 
$str
”” /
,
””/ 0
column
•• 
:
•• 
$str
•• *
)
••* +
;
••+ ,
}
–– 	
	protected
™™ 
override
™™ 
void
™™ 
Down
™™  $
(
™™$ %
MigrationBuilder
™™% 5
migrationBuilder
™™6 F
)
™™F G
{
šš 	
migrationBuilder
›› 
.
›› 
	DropTable
›› &
(
››& '
name
œœ 
:
œœ 
$str
œœ +
)
œœ+ ,
;
œœ, -
migrationBuilder
 
.
 
	DropTable
 &
(
& '
name
ŸŸ 
:
ŸŸ 
$str
ŸŸ .
)
ŸŸ. /
;
ŸŸ/ 0
migrationBuilder
¡¡ 
.
¡¡ 
	DropTable
¡¡ &
(
¡¡& '
name
¢¢ 
:
¢¢ 
$str
¢¢ -
)
¢¢- .
;
¢¢. /
migrationBuilder
¤¤ 
.
¤¤ 
	DropTable
¤¤ &
(
¤¤& '
name
¥¥ 
:
¥¥ 
$str
¥¥ &
)
¥¥& '
;
¥¥' (
migrationBuilder
§§ 
.
§§ 

UpdateData
§§ '
(
§§' (
table
¨¨ 
:
¨¨ 
$str
¨¨ $
,
¨¨$ %
	keyColumn
©© 
:
©© 
$str
©© 
,
©©  
keyValue
ªª 
:
ªª 
$str
ªª +
,
ªª+ ,
columns
«« 
:
«« 
new
«« 
[
«« 
]
«« 
{
««  
$str
««! 3
,
««3 4
$str
««5 A
,
««A B
$str
««C Q
,
««Q R
$str
««S b
}
««c d
,
««d e
values
¬¬ 
:
¬¬ 
new
¬¬ 
object
¬¬ "
[
¬¬" #
]
¬¬# $
{
¬¬% &
$str
¬¬' M
,
¬¬M N
new
¬¬O R
DateTime
¬¬S [
(
¬¬[ \
$num
¬¬\ `
,
¬¬` a
$num
¬¬b c
,
¬¬c d
$num
¬¬e g
,
¬¬g h
$num
¬¬i j
,
¬¬j k
$num
¬¬l n
,
¬¬n o
$num
¬¬p r
,
¬¬r s
$num
¬¬t u
,
¬¬u v
DateTimeKind¬¬w ƒ
.¬¬ƒ „
Utc¬¬„ ‡
)¬¬‡ ˆ
.¬¬ˆ ‰
AddTicks¬¬‰ ‘
(¬¬‘ ’
$num¬¬’ –
)¬¬– —
,¬¬— ˜
$str¬¬™ ï
,¬¬ï ğ
$str¬¬ñ —
}¬¬˜ ™
)¬¬™ š
;¬¬š ›
}
­­ 	
}
®® 
}¯¯ £l
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
99€ Œ
,
99Œ 
$str
99 •
,
99• –
$str
99— §
,
99§ ¨
$str
99© ³
,
99³ ´
$str
99µ ½
,
99½ ¾
$str
99¿ Ï
,
99Ï Ğ
$str
99Ñ İ
,
99İ Ş
$str
99ß ğ
,
99ğ ñ
$str
99ò †
,
99† ‡
$str
99ˆ –
,
99– —
$str
99˜ ¥
,
99¥ ¦
$str
99§ ½
,
99½ ¾
$str
99¿ Î
,
99Î Ï
$str
99Ğ Û
,
99Û Ü
$str
99İ ï
,
99ï ğ
$str
99ñ ı
,
99ı ş
$str
99ÿ ‰
}
99Š ‹
,
99‹ Œ
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
$num	::| €
,
::€ 
$num
::‚ ƒ
,
::ƒ „
$num
::… †
,
::† ‡
$num
::ˆ ‰
,
::‰ Š
$num
::‹ Œ
,
::Œ 
$num
:: 
,
:: 
$num
::‘ ’
,
::’ “
DateTimeKind
::”  
.
::  ¡
Unspecified
::¡ ¬
)
::¬ ­
,
::­ ®
$str
::¯ Õ
,
::Õ Ö
$str
::× à
,
::à á
new
::â å
DateTime
::æ î
(
::î ï
$num
::ï ó
,
::ó ô
$num
::õ ö
,
::ö ÷
$num
::ø ú
,
::ú û
$num
::ü ı
,
::ı ş
$num
::ÿ 
,
:: ‚
$num
::ƒ …
,
::… †
$num
::‡ ˆ
,
::ˆ ‰
DateTimeKind
::Š –
.
::– —
Utc
::— š
)
::š ›
.
::› œ
AddTicks
::œ ¤
(
::¤ ¥
$num
::¥ ©
)
::© ª
,
::ª «
$str
::¬ ½
,
::½ ¾
true
::¿ Ã
,
::Ã Ä
$str
::Å Ñ
,
::Ñ Ò
$str
::Ó Ù
,
::Ù Ú
true
::Û ß
,
::ß à
null
::á å
,
::å æ
$str
::ç ø
,
::ø ù
$str
::ú ‹
,
::‹ Œ
$str
:: ã
,
::ã ä
$str
::å ñ
,
::ñ ò
true
::ó ÷
,
::÷ ø
$str
::ù Ÿ
,
::Ÿ  
$str
::¡ ¬
,
::¬ ­
false
::® ³
,
::³ ´
new
::µ ¸
DateTime
::¹ Á
(
::Á Â
$num
::Â Æ
,
::Æ Ç
$num
::È É
,
::É Ê
$num
::Ë Í
,
::Í Î
$num
::Ï Ğ
,
::Ğ Ñ
$num
::Ò Ó
,
::Ó Ô
$num
::Õ Ö
,
::Ö ×
$num
::Ø Ù
,
::Ù Ú
DateTimeKind
::Û ç
.
::ç è
Unspecified
::è ó
)
::ó ô
,
::ô õ
$str
::ö ‡
}
::ˆ ‰
)
::‰ Š
;
::Š ‹
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
ee€ Œ
,
eeŒ 
$str
ee •
,
ee• –
$str
ee— §
,
ee§ ¨
$str
ee© ³
,
ee³ ´
$str
eeµ ½
,
ee½ ¾
$str
ee¿ Ï
,
eeÏ Ğ
$str
eeÑ İ
,
eeİ Ş
$str
eeß ğ
,
eeğ ñ
$str
eeò †
,
ee† ‡
$str
eeˆ –
,
ee– —
$str
ee˜ ¥
,
ee¥ ¦
$str
ee§ ½
,
ee½ ¾
$str
ee¿ Î
,
eeÎ Ï
$str
eeĞ Û
,
eeÛ Ü
$str
eeİ ï
,
eeï ğ
$str
eeñ ı
,
eeı ş
$str
eeÿ ‰
}
eeŠ ‹
,
ee‹ Œ
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
$num	ff| €
,
ff€ 
$num
ff‚ ƒ
,
ffƒ „
$num
ff… †
,
ff† ‡
$num
ffˆ ‰
,
ff‰ Š
$num
ff‹ Œ
,
ffŒ 
$num
ff 
,
ff 
$num
ff‘ ’
,
ff’ “
DateTimeKind
ff”  
.
ff  ¡
Unspecified
ff¡ ¬
)
ff¬ ­
,
ff­ ®
$str
ff¯ Õ
,
ffÕ Ö
$str
ff× à
,
ffà á
new
ffâ å
DateTime
ffæ î
(
ffî ï
$num
ffï ó
,
ffó ô
$num
ffõ ö
,
ffö ÷
$num
ffø ú
,
ffú û
$num
ffü ı
,
ffı ş
$num
ffÿ €
,
ff€ 
$num
ff‚ „
,
ff„ …
$num
ff† ‰
,
ff‰ Š
DateTimeKind
ff‹ —
.
ff— ˜
Utc
ff˜ ›
)
ff› œ
.
ffœ 
AddTicks
ff ¥
(
ff¥ ¦
$num
ff¦ ª
)
ffª «
,
ff« ¬
$str
ff­ ¾
,
ff¾ ¿
true
ffÀ Ä
,
ffÄ Å
$str
ffÆ Ò
,
ffÒ Ó
$str
ffÔ Ú
,
ffÚ Û
true
ffÜ à
,
ffà á
null
ffâ æ
,
ffæ ç
$str
ffè ù
,
ffù ú
$str
ffû Œ
,
ffŒ 
$str
ff ä
,
ffä å
$str
ffæ ò
,
ffò ó
true
ffô ø
,
ffø ù
$str
ffú  
,
ff  ¡
$str
ff¢ ­
,
ff­ ®
false
ff¯ ´
,
ff´ µ
new
ff¶ ¹
DateTime
ffº Â
(
ffÂ Ã
$num
ffÃ Ç
,
ffÇ È
$num
ffÉ Ê
,
ffÊ Ë
$num
ffÌ Î
,
ffÎ Ï
$num
ffĞ Ñ
,
ffÑ Ò
$num
ffÓ Ô
,
ffÔ Õ
$num
ffÖ Ø
,
ffØ Ù
$num
ffÚ İ
,
ffİ Ş
DateTimeKind
ffß ë
.
ffë ì
Utc
ffì ï
)
ffï ğ
.
ffğ ñ
AddTicks
ffñ ù
(
ffù ú
$num
ffú ş
)
ffş ÿ
,
ffÿ €
$str
ff ’
}
ff“ ”
)
ff” •
;
ff• –
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
}nn ‹:
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
}yy Ø:
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240625020837_AddMorePropsCourses.cs
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
}{{ »(
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
}KK ôÖ
€D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240625015607_ModifiedBaseEntity.cs
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
€€ 
:
€€ 
$str
€€ #
,
€€# $
type
 
:
 
$str
 !
,
! "
nullable
‚‚ 
:
‚‚ 
true
‚‚ 
,
‚‚ 

oldClrType
ƒƒ 
:
ƒƒ 
typeof
ƒƒ "
(
ƒƒ" #
DateTime
ƒƒ# +
)
ƒƒ+ ,
,
ƒƒ, -
oldType
„„ 
:
„„ 
$str
„„ $
)
„„$ %
;
„„% &
migrationBuilder
†† 
.
†† 
AlterColumn
†† (
<
††( )
string
††) /
>
††/ 0
(
††0 1
name
‡‡ 
:
‡‡ 
$str
‡‡  
,
‡‡  !
table
ˆˆ 
:
ˆˆ 
$str
ˆˆ #
,
ˆˆ# $
type
‰‰ 
:
‰‰ 
$str
‰‰ %
,
‰‰% &
nullable
ŠŠ 
:
ŠŠ 
true
ŠŠ 
,
ŠŠ 

oldClrType
‹‹ 
:
‹‹ 
typeof
‹‹ "
(
‹‹" #
string
‹‹# )
)
‹‹) *
,
‹‹* +
oldType
ŒŒ 
:
ŒŒ 
$str
ŒŒ (
)
ŒŒ( )
;
ŒŒ) *
}
 	
	protected
 
override
 
void
 
Down
  $
(
$ %
MigrationBuilder
% 5
migrationBuilder
6 F
)
F G
{
‘‘ 	
migrationBuilder
’’ 
.
’’ 
AlterColumn
’’ (
<
’’( )
DateTime
’’) 1
>
’’1 2
(
’’2 3
name
““ 
:
““ 
$str
““ "
,
““" #
table
”” 
:
”” 
$str
”” *
,
””* +
type
•• 
:
•• 
$str
•• !
,
••! "
nullable
–– 
:
–– 
false
–– 
,
––  
defaultValue
—— 
:
—— 
new
—— !
DateTime
——" *
(
——* +
$num
——+ ,
,
——, -
$num
——. /
,
——/ 0
$num
——1 2
,
——2 3
$num
——4 5
,
——5 6
$num
——7 8
,
——8 9
$num
——: ;
,
——; <
$num
——= >
,
——> ?
DateTimeKind
——@ L
.
——L M
Unspecified
——M X
)
——X Y
,
——Y Z

oldClrType
˜˜ 
:
˜˜ 
typeof
˜˜ "
(
˜˜" #
DateTime
˜˜# +
)
˜˜+ ,
,
˜˜, -
oldType
™™ 
:
™™ 
$str
™™ $
,
™™$ %
oldNullable
šš 
:
šš 
true
šš !
)
šš! "
;
šš" #
migrationBuilder
œœ 
.
œœ 
AlterColumn
œœ (
<
œœ( )
string
œœ) /
>
œœ/ 0
(
œœ0 1
name
 
:
 
$str
  
,
  !
table
 
:
 
$str
 *
,
* +
type
ŸŸ 
:
ŸŸ 
$str
ŸŸ %
,
ŸŸ% &
nullable
   
:
   
false
   
,
    
defaultValue
¡¡ 
:
¡¡ 
$str
¡¡  
,
¡¡  !

oldClrType
¢¢ 
:
¢¢ 
typeof
¢¢ "
(
¢¢" #
string
¢¢# )
)
¢¢) *
,
¢¢* +
oldType
££ 
:
££ 
$str
££ (
,
££( )
oldNullable
¤¤ 
:
¤¤ 
true
¤¤ !
)
¤¤! "
;
¤¤" #
migrationBuilder
¦¦ 
.
¦¦ 
AlterColumn
¦¦ (
<
¦¦( )
DateTime
¦¦) 1
>
¦¦1 2
(
¦¦2 3
name
§§ 
:
§§ 
$str
§§ "
,
§§" #
table
¨¨ 
:
¨¨ 
$str
¨¨ *
,
¨¨* +
type
©© 
:
©© 
$str
©© !
,
©©! "
nullable
ªª 
:
ªª 
false
ªª 
,
ªª  
defaultValue
«« 
:
«« 
new
«« !
DateTime
««" *
(
««* +
$num
««+ ,
,
««, -
$num
««. /
,
««/ 0
$num
««1 2
,
««2 3
$num
««4 5
,
««5 6
$num
««7 8
,
««8 9
$num
««: ;
,
««; <
$num
««= >
,
««> ?
DateTimeKind
««@ L
.
««L M
Unspecified
««M X
)
««X Y
,
««Y Z

oldClrType
¬¬ 
:
¬¬ 
typeof
¬¬ "
(
¬¬" #
DateTime
¬¬# +
)
¬¬+ ,
,
¬¬, -
oldType
­­ 
:
­­ 
$str
­­ $
,
­­$ %
oldNullable
®® 
:
®® 
true
®® !
)
®®! "
;
®®" #
migrationBuilder
°° 
.
°° 
AlterColumn
°° (
<
°°( )
string
°°) /
>
°°/ 0
(
°°0 1
name
±± 
:
±± 
$str
±±  
,
±±  !
table
²² 
:
²² 
$str
²² *
,
²²* +
type
³³ 
:
³³ 
$str
³³ %
,
³³% &
nullable
´´ 
:
´´ 
false
´´ 
,
´´  
defaultValue
µµ 
:
µµ 
$str
µµ  
,
µµ  !

oldClrType
¶¶ 
:
¶¶ 
typeof
¶¶ "
(
¶¶" #
string
¶¶# )
)
¶¶) *
,
¶¶* +
oldType
·· 
:
·· 
$str
·· (
,
··( )
oldNullable
¸¸ 
:
¸¸ 
true
¸¸ !
)
¸¸! "
;
¸¸" #
migrationBuilder
ºº 
.
ºº 
AlterColumn
ºº (
<
ºº( )
DateTime
ºº) 1
>
ºº1 2
(
ºº2 3
name
»» 
:
»» 
$str
»» "
,
»»" #
table
¼¼ 
:
¼¼ 
$str
¼¼ +
,
¼¼+ ,
type
½½ 
:
½½ 
$str
½½ !
,
½½! "
nullable
¾¾ 
:
¾¾ 
false
¾¾ 
,
¾¾  
defaultValue
¿¿ 
:
¿¿ 
new
¿¿ !
DateTime
¿¿" *
(
¿¿* +
$num
¿¿+ ,
,
¿¿, -
$num
¿¿. /
,
¿¿/ 0
$num
¿¿1 2
,
¿¿2 3
$num
¿¿4 5
,
¿¿5 6
$num
¿¿7 8
,
¿¿8 9
$num
¿¿: ;
,
¿¿; <
$num
¿¿= >
,
¿¿> ?
DateTimeKind
¿¿@ L
.
¿¿L M
Unspecified
¿¿M X
)
¿¿X Y
,
¿¿Y Z

oldClrType
ÀÀ 
:
ÀÀ 
typeof
ÀÀ "
(
ÀÀ" #
DateTime
ÀÀ# +
)
ÀÀ+ ,
,
ÀÀ, -
oldType
ÁÁ 
:
ÁÁ 
$str
ÁÁ $
,
ÁÁ$ %
oldNullable
ÂÂ 
:
ÂÂ 
true
ÂÂ !
)
ÂÂ! "
;
ÂÂ" #
migrationBuilder
ÄÄ 
.
ÄÄ 
AlterColumn
ÄÄ (
<
ÄÄ( )
string
ÄÄ) /
>
ÄÄ/ 0
(
ÄÄ0 1
name
ÅÅ 
:
ÅÅ 
$str
ÅÅ  
,
ÅÅ  !
table
ÆÆ 
:
ÆÆ 
$str
ÆÆ +
,
ÆÆ+ ,
type
ÇÇ 
:
ÇÇ 
$str
ÇÇ %
,
ÇÇ% &
nullable
ÈÈ 
:
ÈÈ 
false
ÈÈ 
,
ÈÈ  
defaultValue
ÉÉ 
:
ÉÉ 
$str
ÉÉ  
,
ÉÉ  !

oldClrType
ÊÊ 
:
ÊÊ 
typeof
ÊÊ "
(
ÊÊ" #
string
ÊÊ# )
)
ÊÊ) *
,
ÊÊ* +
oldType
ËË 
:
ËË 
$str
ËË (
,
ËË( )
oldNullable
ÌÌ 
:
ÌÌ 
true
ÌÌ !
)
ÌÌ! "
;
ÌÌ" #
migrationBuilder
ÎÎ 
.
ÎÎ 
AlterColumn
ÎÎ (
<
ÎÎ( )
DateTime
ÎÎ) 1
>
ÎÎ1 2
(
ÎÎ2 3
name
ÏÏ 
:
ÏÏ 
$str
ÏÏ "
,
ÏÏ" #
table
ĞĞ 
:
ĞĞ 
$str
ĞĞ +
,
ĞĞ+ ,
type
ÑÑ 
:
ÑÑ 
$str
ÑÑ !
,
ÑÑ! "
nullable
ÒÒ 
:
ÒÒ 
false
ÒÒ 
,
ÒÒ  
defaultValue
ÓÓ 
:
ÓÓ 
new
ÓÓ !
DateTime
ÓÓ" *
(
ÓÓ* +
$num
ÓÓ+ ,
,
ÓÓ, -
$num
ÓÓ. /
,
ÓÓ/ 0
$num
ÓÓ1 2
,
ÓÓ2 3
$num
ÓÓ4 5
,
ÓÓ5 6
$num
ÓÓ7 8
,
ÓÓ8 9
$num
ÓÓ: ;
,
ÓÓ; <
$num
ÓÓ= >
,
ÓÓ> ?
DateTimeKind
ÓÓ@ L
.
ÓÓL M
Unspecified
ÓÓM X
)
ÓÓX Y
,
ÓÓY Z

oldClrType
ÔÔ 
:
ÔÔ 
typeof
ÔÔ "
(
ÔÔ" #
DateTime
ÔÔ# +
)
ÔÔ+ ,
,
ÔÔ, -
oldType
ÕÕ 
:
ÕÕ 
$str
ÕÕ $
,
ÕÕ$ %
oldNullable
ÖÖ 
:
ÖÖ 
true
ÖÖ !
)
ÖÖ! "
;
ÖÖ" #
migrationBuilder
ØØ 
.
ØØ 
AlterColumn
ØØ (
<
ØØ( )
string
ØØ) /
>
ØØ/ 0
(
ØØ0 1
name
ÙÙ 
:
ÙÙ 
$str
ÙÙ  
,
ÙÙ  !
table
ÚÚ 
:
ÚÚ 
$str
ÚÚ +
,
ÚÚ+ ,
type
ÛÛ 
:
ÛÛ 
$str
ÛÛ %
,
ÛÛ% &
nullable
ÜÜ 
:
ÜÜ 
false
ÜÜ 
,
ÜÜ  
defaultValue
İİ 
:
İİ 
$str
İİ  
,
İİ  !

oldClrType
ŞŞ 
:
ŞŞ 
typeof
ŞŞ "
(
ŞŞ" #
string
ŞŞ# )
)
ŞŞ) *
,
ŞŞ* +
oldType
ßß 
:
ßß 
$str
ßß (
,
ßß( )
oldNullable
àà 
:
àà 
true
àà !
)
àà! "
;
àà" #
migrationBuilder
ââ 
.
ââ 
AlterColumn
ââ (
<
ââ( )
DateTime
ââ) 1
>
ââ1 2
(
ââ2 3
name
ãã 
:
ãã 
$str
ãã "
,
ãã" #
table
ää 
:
ää 
$str
ää '
,
ää' (
type
åå 
:
åå 
$str
åå !
,
åå! "
nullable
ææ 
:
ææ 
false
ææ 
,
ææ  
defaultValue
çç 
:
çç 
new
çç !
DateTime
çç" *
(
çç* +
$num
çç+ ,
,
çç, -
$num
çç. /
,
çç/ 0
$num
çç1 2
,
çç2 3
$num
çç4 5
,
çç5 6
$num
çç7 8
,
çç8 9
$num
çç: ;
,
çç; <
$num
çç= >
,
çç> ?
DateTimeKind
çç@ L
.
ççL M
Unspecified
ççM X
)
ççX Y
,
ççY Z

oldClrType
èè 
:
èè 
typeof
èè "
(
èè" #
DateTime
èè# +
)
èè+ ,
,
èè, -
oldType
éé 
:
éé 
$str
éé $
,
éé$ %
oldNullable
êê 
:
êê 
true
êê !
)
êê! "
;
êê" #
migrationBuilder
ìì 
.
ìì 
AlterColumn
ìì (
<
ìì( )
string
ìì) /
>
ìì/ 0
(
ìì0 1
name
íí 
:
íí 
$str
íí  
,
íí  !
table
îî 
:
îî 
$str
îî '
,
îî' (
type
ïï 
:
ïï 
$str
ïï %
,
ïï% &
nullable
ğğ 
:
ğğ 
false
ğğ 
,
ğğ  
defaultValue
ññ 
:
ññ 
$str
ññ  
,
ññ  !

oldClrType
òò 
:
òò 
typeof
òò "
(
òò" #
string
òò# )
)
òò) *
,
òò* +
oldType
óó 
:
óó 
$str
óó (
,
óó( )
oldNullable
ôô 
:
ôô 
true
ôô !
)
ôô! "
;
ôô" #
migrationBuilder
öö 
.
öö 
AlterColumn
öö (
<
öö( )
DateTime
öö) 1
>
öö1 2
(
öö2 3
name
÷÷ 
:
÷÷ 
$str
÷÷ "
,
÷÷" #
table
øø 
:
øø 
$str
øø '
,
øø' (
type
ùù 
:
ùù 
$str
ùù !
,
ùù! "
nullable
úú 
:
úú 
false
úú 
,
úú  
defaultValue
ûû 
:
ûû 
new
ûû !
DateTime
ûû" *
(
ûû* +
$num
ûû+ ,
,
ûû, -
$num
ûû. /
,
ûû/ 0
$num
ûû1 2
,
ûû2 3
$num
ûû4 5
,
ûû5 6
$num
ûû7 8
,
ûû8 9
$num
ûû: ;
,
ûû; <
$num
ûû= >
,
ûû> ?
DateTimeKind
ûû@ L
.
ûûL M
Unspecified
ûûM X
)
ûûX Y
,
ûûY Z

oldClrType
üü 
:
üü 
typeof
üü "
(
üü" #
DateTime
üü# +
)
üü+ ,
,
üü, -
oldType
ıı 
:
ıı 
$str
ıı $
,
ıı$ %
oldNullable
şş 
:
şş 
true
şş !
)
şş! "
;
şş" #
migrationBuilder
€€ 
.
€€ 
AlterColumn
€€ (
<
€€( )
string
€€) /
>
€€/ 0
(
€€0 1
name
 
:
 
$str
  
,
  !
table
‚‚ 
:
‚‚ 
$str
‚‚ '
,
‚‚' (
type
ƒƒ 
:
ƒƒ 
$str
ƒƒ %
,
ƒƒ% &
nullable
„„ 
:
„„ 
false
„„ 
,
„„  
defaultValue
…… 
:
…… 
$str
……  
,
……  !

oldClrType
†† 
:
†† 
typeof
†† "
(
††" #
string
††# )
)
††) *
,
††* +
oldType
‡‡ 
:
‡‡ 
$str
‡‡ (
,
‡‡( )
oldNullable
ˆˆ 
:
ˆˆ 
true
ˆˆ !
)
ˆˆ! "
;
ˆˆ" #
migrationBuilder
ŠŠ 
.
ŠŠ 
AlterColumn
ŠŠ (
<
ŠŠ( )
DateTime
ŠŠ) 1
>
ŠŠ1 2
(
ŠŠ2 3
name
‹‹ 
:
‹‹ 
$str
‹‹ "
,
‹‹" #
table
ŒŒ 
:
ŒŒ 
$str
ŒŒ #
,
ŒŒ# $
type
 
:
 
$str
 !
,
! "
nullable
 
:
 
false
 
,
  
defaultValue
 
:
 
new
 !
DateTime
" *
(
* +
$num
+ ,
,
, -
$num
. /
,
/ 0
$num
1 2
,
2 3
$num
4 5
,
5 6
$num
7 8
,
8 9
$num
: ;
,
; <
$num
= >
,
> ?
DateTimeKind
@ L
.
L M
Unspecified
M X
)
X Y
,
Y Z

oldClrType
 
:
 
typeof
 "
(
" #
DateTime
# +
)
+ ,
,
, -
oldType
‘‘ 
:
‘‘ 
$str
‘‘ $
,
‘‘$ %
oldNullable
’’ 
:
’’ 
true
’’ !
)
’’! "
;
’’" #
migrationBuilder
”” 
.
”” 
AlterColumn
”” (
<
””( )
string
””) /
>
””/ 0
(
””0 1
name
•• 
:
•• 
$str
••  
,
••  !
table
–– 
:
–– 
$str
–– #
,
––# $
type
—— 
:
—— 
$str
—— %
,
——% &
nullable
˜˜ 
:
˜˜ 
false
˜˜ 
,
˜˜  
defaultValue
™™ 
:
™™ 
$str
™™  
,
™™  !

oldClrType
šš 
:
šš 
typeof
šš "
(
šš" #
string
šš# )
)
šš) *
,
šš* +
oldType
›› 
:
›› 
$str
›› (
,
››( )
oldNullable
œœ 
:
œœ 
true
œœ !
)
œœ! "
;
œœ" #
migrationBuilder
 
.
 
AlterColumn
 (
<
( )
DateTime
) 1
>
1 2
(
2 3
name
ŸŸ 
:
ŸŸ 
$str
ŸŸ "
,
ŸŸ" #
table
   
:
   
$str
   #
,
  # $
type
¡¡ 
:
¡¡ 
$str
¡¡ !
,
¡¡! "
nullable
¢¢ 
:
¢¢ 
false
¢¢ 
,
¢¢  
defaultValue
££ 
:
££ 
new
££ !
DateTime
££" *
(
££* +
$num
££+ ,
,
££, -
$num
££. /
,
££/ 0
$num
££1 2
,
££2 3
$num
££4 5
,
££5 6
$num
££7 8
,
££8 9
$num
££: ;
,
££; <
$num
££= >
,
££> ?
DateTimeKind
££@ L
.
££L M
Unspecified
££M X
)
££X Y
,
££Y Z

oldClrType
¤¤ 
:
¤¤ 
typeof
¤¤ "
(
¤¤" #
DateTime
¤¤# +
)
¤¤+ ,
,
¤¤, -
oldType
¥¥ 
:
¥¥ 
$str
¥¥ $
,
¥¥$ %
oldNullable
¦¦ 
:
¦¦ 
true
¦¦ !
)
¦¦! "
;
¦¦" #
migrationBuilder
¨¨ 
.
¨¨ 
AlterColumn
¨¨ (
<
¨¨( )
string
¨¨) /
>
¨¨/ 0
(
¨¨0 1
name
©© 
:
©© 
$str
©©  
,
©©  !
table
ªª 
:
ªª 
$str
ªª #
,
ªª# $
type
«« 
:
«« 
$str
«« %
,
««% &
nullable
¬¬ 
:
¬¬ 
false
¬¬ 
,
¬¬  
defaultValue
­­ 
:
­­ 
$str
­­  
,
­­  !

oldClrType
®® 
:
®® 
typeof
®® "
(
®®" #
string
®®# )
)
®®) *
,
®®* +
oldType
¯¯ 
:
¯¯ 
$str
¯¯ (
,
¯¯( )
oldNullable
°° 
:
°° 
true
°° !
)
°°! "
;
°°" #
}
±± 	
}
²² 
}³³ º$
ŒD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240620015801_AddCreateTimeInApplicationUser.cs
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
DateTimeKind	y …
.
… †
Utc
† ‰
)
‰ Š
.
Š ‹
AddTicks
‹ “
(
“ ”
$num
” ˜
)
˜ ™
,
™ š
$str
› ñ
,
ñ ò
$str
ó ™
,
™ š
new
› 
DateTime
Ÿ §
(
§ ¨
$num
¨ ¬
,
¬ ­
$num
® ¯
,
¯ °
$num
± ³
,
³ ´
$num
µ ¶
,
¶ ·
$num
¸ º
,
º »
$num
¼ ¾
,
¾ ¿
$num
À Ã
,
Ã Ä
DateTimeKind
Å Ñ
.
Ñ Ò
Utc
Ò Õ
)
Õ Ö
.
Ö ×
AddTicks
× ß
(
ß à
$num
à ã
)
ã ä
}
å æ
)
æ ç
;
ç è
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
$str	((O ¥
,
((¥ ¦
$str
((§ Í
,
((Í Î
new
((Ï Ò
DateTime
((Ó Û
(
((Û Ü
$num
((Ü à
,
((à á
$num
((â ã
,
((ã ä
$num
((å ç
,
((ç è
$num
((é ê
,
((ê ë
$num
((ì î
,
((î ï
$num
((ğ ò
,
((ò ó
$num
((ô ÷
,
((÷ ø
DateTimeKind
((ù …
.
((… †
Utc
((† ‰
)
((‰ Š
.
((Š ‹
AddTicks
((‹ “
(
((“ ”
$num
((” ˜
)
((˜ ™
}
((š ›
)
((› œ
;
((œ 
})) 	
}** 
}++ Å*
‰D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240619024532_AddMorePropertiesInstructor.cs
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
$str	%%O ¥
,
%%¥ ¦
$str
%%§ Í
,
%%Í Î
new
%%Ï Ò
DateTime
%%Ó Û
(
%%Û Ü
$num
%%Ü à
,
%%à á
$num
%%â ã
,
%%ã ä
$num
%%å ç
,
%%ç è
$num
%%é ê
,
%%ê ë
$num
%%ì î
,
%%î ï
$num
%%ğ ò
,
%%ò ó
$num
%%ô ÷
,
%%÷ ø
DateTimeKind
%%ù …
.
%%… †
Utc
%%† ‰
)
%%‰ Š
.
%%Š ‹
AddTicks
%%‹ “
(
%%“ ”
$num
%%” ˜
)
%%˜ ™
}
%%š ›
)
%%› œ
;
%%œ 
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
$str	<<O ¥
,
<<¥ ¦
$str
<<§ Í
,
<<Í Î
new
<<Ï Ò
DateTime
<<Ó Û
(
<<Û Ü
$num
<<Ü à
,
<<à á
$num
<<â ã
,
<<ã ä
$num
<<å ç
,
<<ç è
$num
<<é ê
,
<<ê ë
$num
<<ì î
,
<<î ï
$num
<<ğ ò
,
<<ò ó
$num
<<ô ÷
,
<<÷ ø
DateTimeKind
<<ù …
.
<<… †
Utc
<<† ‰
)
<<‰ Š
.
<<Š ‹
AddTicks
<<‹ “
(
<<“ ”
$num
<<” ˜
)
<<˜ ™
}
<<š ›
)
<<› œ
;
<<œ 
}== 	
}>> 
}?? ı 
‰D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240619024142_RemoveIsAceptedInInstructor.cs
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
$str	O ¥
,
¥ ¦
$str
§ Í
,
Í Î
new
Ï Ò
DateTime
Ó Û
(
Û Ü
$num
Ü à
,
à á
$num
â ã
,
ã ä
$num
å ç
,
ç è
$num
é ê
,
ê ë
$num
ì î
,
î ï
$num
ğ ò
,
ò ó
$num
ô ÷
,
÷ ø
DateTimeKind
ù …
.
… †
Utc
† ‰
)
‰ Š
.
Š ‹
AddTicks
‹ “
(
“ ”
$num
” ˜
)
˜ ™
}
š ›
)
› œ
;
œ 
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
$str	))O ¥
,
))¥ ¦
$str
))§ Í
,
))Í Î
new
))Ï Ò
DateTime
))Ó Û
(
))Û Ü
$num
))Ü à
,
))à á
$num
))â ã
,
))ã ä
$num
))å ç
,
))ç è
$num
))é ë
,
))ë ì
$num
))í ï
,
))ï ğ
$num
))ñ ó
,
))ó ô
$num
))õ ø
,
))ø ù
DateTimeKind
))ú †
.
))† ‡
Utc
))‡ Š
)
))Š ‹
.
))‹ Œ
AddTicks
))Œ ”
(
))” •
$num
))• ™
)
))™ š
}
))› œ
)
))œ 
;
)) 
}** 	
}++ 
},, ¦
ˆD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240617111413_RemoveRejectedInInstructor.cs
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
}33 ò
‡D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614115054_AddEmailTemplatesSeedData.cs
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
}$$ ê
ƒD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614074722_SeedAdminUserAndRoles.cs
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
}BB À8
ƒD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614063232_AddEmailTemplateTable.cs
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
}22 Œ
ƒD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614063134_AddStatusToBaseEntity.cs
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
}(( ó
™D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614022706_AddRejectedByAndAcceptedByInTableInstructor.cs
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
}'' Ë
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614022444_AddMorePropertiesInTableInstructor.cs
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
}<< Ä$
†D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614021640_AddTableInstructorRating.cs
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
}22 Ì$
‡D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614020848_AddTableInstructorComment.cs
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
}22 ›<
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240614013800_ModifyCategoryTable.cs
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
}rr ‰
D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\Migrations\20240608075025_AddUpdateTimeForApplicationUser.cs
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
} ØŠ
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
€€ 
:
€€ 
table
€€ 
=>
€€ !
new
€€" %
{
 
LoginProvider
‚‚ !
=
‚‚" #
table
‚‚$ )
.
‚‚) *
Column
‚‚* 0
<
‚‚0 1
string
‚‚1 7
>
‚‚7 8
(
‚‚8 9
type
‚‚9 =
:
‚‚= >
$str
‚‚? N
,
‚‚N O
nullable
‚‚P X
:
‚‚X Y
false
‚‚Z _
)
‚‚_ `
,
‚‚` a
ProviderKey
ƒƒ 
=
ƒƒ  !
table
ƒƒ" '
.
ƒƒ' (
Column
ƒƒ( .
<
ƒƒ. /
string
ƒƒ/ 5
>
ƒƒ5 6
(
ƒƒ6 7
type
ƒƒ7 ;
:
ƒƒ; <
$str
ƒƒ= L
,
ƒƒL M
nullable
ƒƒN V
:
ƒƒV W
false
ƒƒX ]
)
ƒƒ] ^
,
ƒƒ^ _!
ProviderDisplayName
„„ '
=
„„( )
table
„„* /
.
„„/ 0
Column
„„0 6
<
„„6 7
string
„„7 =
>
„„= >
(
„„> ?
type
„„? C
:
„„C D
$str
„„E T
,
„„T U
nullable
„„V ^
:
„„^ _
true
„„` d
)
„„d e
,
„„e f
UserId
…… 
=
…… 
table
…… "
.
……" #
Column
……# )
<
……) *
string
……* 0
>
……0 1
(
……1 2
type
……2 6
:
……6 7
$str
……8 G
,
……G H
nullable
……I Q
:
……Q R
false
……S X
)
……X Y
}
†† 
,
†† 
constraints
‡‡ 
:
‡‡ 
table
‡‡ "
=>
‡‡# %
{
ˆˆ 
table
‰‰ 
.
‰‰ 

PrimaryKey
‰‰ $
(
‰‰$ %
$str
‰‰% :
,
‰‰: ;
x
‰‰< =
=>
‰‰> @
new
‰‰A D
{
‰‰E F
x
‰‰G H
.
‰‰H I
LoginProvider
‰‰I V
,
‰‰V W
x
‰‰X Y
.
‰‰Y Z
ProviderKey
‰‰Z e
}
‰‰f g
)
‰‰g h
;
‰‰h i
table
ŠŠ 
.
ŠŠ 

ForeignKey
ŠŠ $
(
ŠŠ$ %
name
‹‹ 
:
‹‹ 
$str
‹‹ F
,
‹‹F G
column
ŒŒ 
:
ŒŒ 
x
ŒŒ  !
=>
ŒŒ" $
x
ŒŒ% &
.
ŒŒ& '
UserId
ŒŒ' -
,
ŒŒ- .
principalTable
 &
:
& '
$str
( 5
,
5 6
principalColumn
 '
:
' (
$str
) -
,
- .
onDelete
  
:
  !
ReferentialAction
" 3
.
3 4
Cascade
4 ;
)
; <
;
< =
}
 
)
 
;
 
migrationBuilder
’’ 
.
’’ 
CreateTable
’’ (
(
’’( )
name
““ 
:
““ 
$str
““ '
,
““' (
columns
”” 
:
”” 
table
”” 
=>
”” !
new
””" %
{
•• 
UserId
–– 
=
–– 
table
–– "
.
––" #
Column
––# )
<
––) *
string
––* 0
>
––0 1
(
––1 2
type
––2 6
:
––6 7
$str
––8 G
,
––G H
nullable
––I Q
:
––Q R
false
––S X
)
––X Y
,
––Y Z
RoleId
—— 
=
—— 
table
—— "
.
——" #
Column
——# )
<
——) *
string
——* 0
>
——0 1
(
——1 2
type
——2 6
:
——6 7
$str
——8 G
,
——G H
nullable
——I Q
:
——Q R
false
——S X
)
——X Y
}
˜˜ 
,
˜˜ 
constraints
™™ 
:
™™ 
table
™™ "
=>
™™# %
{
šš 
table
›› 
.
›› 

PrimaryKey
›› $
(
››$ %
$str
››% 9
,
››9 :
x
››; <
=>
››= ?
new
››@ C
{
››D E
x
››F G
.
››G H
UserId
››H N
,
››N O
x
››P Q
.
››Q R
RoleId
››R X
}
››Y Z
)
››Z [
;
››[ \
table
œœ 
.
œœ 

ForeignKey
œœ $
(
œœ$ %
name
 
:
 
$str
 E
,
E F
column
 
:
 
x
  !
=>
" $
x
% &
.
& '
RoleId
' -
,
- .
principalTable
ŸŸ &
:
ŸŸ& '
$str
ŸŸ( 5
,
ŸŸ5 6
principalColumn
   '
:
  ' (
$str
  ) -
,
  - .
onDelete
¡¡  
:
¡¡  !
ReferentialAction
¡¡" 3
.
¡¡3 4
Cascade
¡¡4 ;
)
¡¡; <
;
¡¡< =
table
¢¢ 
.
¢¢ 

ForeignKey
¢¢ $
(
¢¢$ %
name
££ 
:
££ 
$str
££ E
,
££E F
column
¤¤ 
:
¤¤ 
x
¤¤  !
=>
¤¤" $
x
¤¤% &
.
¤¤& '
UserId
¤¤' -
,
¤¤- .
principalTable
¥¥ &
:
¥¥& '
$str
¥¥( 5
,
¥¥5 6
principalColumn
¦¦ '
:
¦¦' (
$str
¦¦) -
,
¦¦- .
onDelete
§§  
:
§§  !
ReferentialAction
§§" 3
.
§§3 4
Cascade
§§4 ;
)
§§; <
;
§§< =
}
¨¨ 
)
¨¨ 
;
¨¨ 
migrationBuilder
ªª 
.
ªª 
CreateTable
ªª (
(
ªª( )
name
«« 
:
«« 
$str
«« (
,
««( )
columns
¬¬ 
:
¬¬ 
table
¬¬ 
=>
¬¬ !
new
¬¬" %
{
­­ 
UserId
®® 
=
®® 
table
®® "
.
®®" #
Column
®®# )
<
®®) *
string
®®* 0
>
®®0 1
(
®®1 2
type
®®2 6
:
®®6 7
$str
®®8 G
,
®®G H
nullable
®®I Q
:
®®Q R
false
®®S X
)
®®X Y
,
®®Y Z
LoginProvider
¯¯ !
=
¯¯" #
table
¯¯$ )
.
¯¯) *
Column
¯¯* 0
<
¯¯0 1
string
¯¯1 7
>
¯¯7 8
(
¯¯8 9
type
¯¯9 =
:
¯¯= >
$str
¯¯? N
,
¯¯N O
nullable
¯¯P X
:
¯¯X Y
false
¯¯Z _
)
¯¯_ `
,
¯¯` a
Name
°° 
=
°° 
table
°°  
.
°°  !
Column
°°! '
<
°°' (
string
°°( .
>
°°. /
(
°°/ 0
type
°°0 4
:
°°4 5
$str
°°6 E
,
°°E F
nullable
°°G O
:
°°O P
false
°°Q V
)
°°V W
,
°°W X
Value
±± 
=
±± 
table
±± !
.
±±! "
Column
±±" (
<
±±( )
string
±±) /
>
±±/ 0
(
±±0 1
type
±±1 5
:
±±5 6
$str
±±7 F
,
±±F G
nullable
±±H P
:
±±P Q
true
±±R V
)
±±V W
}
²² 
,
²² 
constraints
³³ 
:
³³ 
table
³³ "
=>
³³# %
{
´´ 
table
µµ 
.
µµ 

PrimaryKey
µµ $
(
µµ$ %
$str
µµ% :
,
µµ: ;
x
µµ< =
=>
µµ> @
new
µµA D
{
µµE F
x
µµG H
.
µµH I
UserId
µµI O
,
µµO P
x
µµQ R
.
µµR S
LoginProvider
µµS `
,
µµ` a
x
µµb c
.
µµc d
Name
µµd h
}
µµi j
)
µµj k
;
µµk l
table
¶¶ 
.
¶¶ 

ForeignKey
¶¶ $
(
¶¶$ %
name
·· 
:
·· 
$str
·· F
,
··F G
column
¸¸ 
:
¸¸ 
x
¸¸  !
=>
¸¸" $
x
¸¸% &
.
¸¸& '
UserId
¸¸' -
,
¸¸- .
principalTable
¹¹ &
:
¹¹& '
$str
¹¹( 5
,
¹¹5 6
principalColumn
ºº '
:
ºº' (
$str
ºº) -
,
ºº- .
onDelete
»»  
:
»»  !
ReferentialAction
»»" 3
.
»»3 4
Cascade
»»4 ;
)
»»; <
;
»»< =
}
¼¼ 
)
¼¼ 
;
¼¼ 
migrationBuilder
¾¾ 
.
¾¾ 
CreateTable
¾¾ (
(
¾¾( )
name
¿¿ 
:
¿¿ 
$str
¿¿ #
,
¿¿# $
columns
ÀÀ 
:
ÀÀ 
table
ÀÀ 
=>
ÀÀ !
new
ÀÀ" %
{
ÁÁ 
InstructorId
ÂÂ  
=
ÂÂ! "
table
ÂÂ# (
.
ÂÂ( )
Column
ÂÂ) /
<
ÂÂ/ 0
Guid
ÂÂ0 4
>
ÂÂ4 5
(
ÂÂ5 6
type
ÂÂ6 :
:
ÂÂ: ;
$str
ÂÂ< N
,
ÂÂN O
nullable
ÂÂP X
:
ÂÂX Y
false
ÂÂZ _
)
ÂÂ_ `
,
ÂÂ` a
UserId
ÃÃ 
=
ÃÃ 
table
ÃÃ "
.
ÃÃ" #
Column
ÃÃ# )
<
ÃÃ) *
string
ÃÃ* 0
>
ÃÃ0 1
(
ÃÃ1 2
type
ÃÃ2 6
:
ÃÃ6 7
$str
ÃÃ8 G
,
ÃÃG H
nullable
ÃÃI Q
:
ÃÃQ R
false
ÃÃS X
)
ÃÃX Y
,
ÃÃY Z
Degree
ÄÄ 
=
ÄÄ 
table
ÄÄ "
.
ÄÄ" #
Column
ÄÄ# )
<
ÄÄ) *
string
ÄÄ* 0
>
ÄÄ0 1
(
ÄÄ1 2
type
ÄÄ2 6
:
ÄÄ6 7
$str
ÄÄ8 G
,
ÄÄG H
nullable
ÄÄI Q
:
ÄÄQ R
false
ÄÄS X
)
ÄÄX Y
,
ÄÄY Z
DegreeImageUrl
ÅÅ "
=
ÅÅ# $
table
ÅÅ% *
.
ÅÅ* +
Column
ÅÅ+ 1
<
ÅÅ1 2
string
ÅÅ2 8
>
ÅÅ8 9
(
ÅÅ9 :
type
ÅÅ: >
:
ÅÅ> ?
$str
ÅÅ@ O
,
ÅÅO P
nullable
ÅÅQ Y
:
ÅÅY Z
true
ÅÅ[ _
)
ÅÅ_ `
,
ÅÅ` a
Industry
ÆÆ 
=
ÆÆ 
table
ÆÆ $
.
ÆÆ$ %
Column
ÆÆ% +
<
ÆÆ+ ,
string
ÆÆ, 2
>
ÆÆ2 3
(
ÆÆ3 4
type
ÆÆ4 8
:
ÆÆ8 9
$str
ÆÆ: I
,
ÆÆI J
nullable
ÆÆK S
:
ÆÆS T
false
ÆÆU Z
)
ÆÆZ [
,
ÆÆ[ \
Introduction
ÇÇ  
=
ÇÇ! "
table
ÇÇ# (
.
ÇÇ( )
Column
ÇÇ) /
<
ÇÇ/ 0
string
ÇÇ0 6
>
ÇÇ6 7
(
ÇÇ7 8
type
ÇÇ8 <
:
ÇÇ< =
$str
ÇÇ> M
,
ÇÇM N
nullable
ÇÇO W
:
ÇÇW X
false
ÇÇY ^
)
ÇÇ^ _
,
ÇÇ_ `

isAccepted
ÈÈ 
=
ÈÈ  
table
ÈÈ! &
.
ÈÈ& '
Column
ÈÈ' -
<
ÈÈ- .
bool
ÈÈ. 2
>
ÈÈ2 3
(
ÈÈ3 4
type
ÈÈ4 8
:
ÈÈ8 9
$str
ÈÈ: ?
,
ÈÈ? @
nullable
ÈÈA I
:
ÈÈI J
false
ÈÈK P
)
ÈÈP Q
}
ÉÉ 
,
ÉÉ 
constraints
ÊÊ 
:
ÊÊ 
table
ÊÊ "
=>
ÊÊ# %
{
ËË 
table
ÌÌ 
.
ÌÌ 

PrimaryKey
ÌÌ $
(
ÌÌ$ %
$str
ÌÌ% 5
,
ÌÌ5 6
x
ÌÌ7 8
=>
ÌÌ9 ;
x
ÌÌ< =
.
ÌÌ= >
InstructorId
ÌÌ> J
)
ÌÌJ K
;
ÌÌK L
table
ÍÍ 
.
ÍÍ 

ForeignKey
ÍÍ $
(
ÍÍ$ %
name
ÎÎ 
:
ÎÎ 
$str
ÎÎ A
,
ÎÎA B
column
ÏÏ 
:
ÏÏ 
x
ÏÏ  !
=>
ÏÏ" $
x
ÏÏ% &
.
ÏÏ& '
UserId
ÏÏ' -
,
ÏÏ- .
principalTable
ĞĞ &
:
ĞĞ& '
$str
ĞĞ( 5
,
ĞĞ5 6
principalColumn
ÑÑ '
:
ÑÑ' (
$str
ÑÑ) -
,
ÑÑ- .
onDelete
ÒÒ  
:
ÒÒ  !
ReferentialAction
ÒÒ" 3
.
ÒÒ3 4
Cascade
ÒÒ4 ;
)
ÒÒ; <
;
ÒÒ< =
}
ÓÓ 
)
ÓÓ 
;
ÓÓ 
migrationBuilder
ÕÕ 
.
ÕÕ 
CreateTable
ÕÕ (
(
ÕÕ( )
name
ÖÖ 
:
ÖÖ 
$str
ÖÖ $
,
ÖÖ$ %
columns
×× 
:
×× 
table
×× 
=>
×× !
new
××" %
{
ØØ 

CardNumber
ÙÙ 
=
ÙÙ  
table
ÙÙ! &
.
ÙÙ& '
Column
ÙÙ' -
<
ÙÙ- .
string
ÙÙ. 4
>
ÙÙ4 5
(
ÙÙ5 6
type
ÙÙ6 :
:
ÙÙ: ;
$str
ÙÙ< K
,
ÙÙK L
nullable
ÙÙM U
:
ÙÙU V
false
ÙÙW \
)
ÙÙ\ ]
,
ÙÙ] ^
CardName
ÚÚ 
=
ÚÚ 
table
ÚÚ $
.
ÚÚ$ %
Column
ÚÚ% +
<
ÚÚ+ ,
string
ÚÚ, 2
>
ÚÚ2 3
(
ÚÚ3 4
type
ÚÚ4 8
:
ÚÚ8 9
$str
ÚÚ: I
,
ÚÚI J
nullable
ÚÚK S
:
ÚÚS T
false
ÚÚU Z
)
ÚÚZ [
,
ÚÚ[ \
CardProvider
ÛÛ  
=
ÛÛ! "
table
ÛÛ# (
.
ÛÛ( )
Column
ÛÛ) /
<
ÛÛ/ 0
string
ÛÛ0 6
>
ÛÛ6 7
(
ÛÛ7 8
type
ÛÛ8 <
:
ÛÛ< =
$str
ÛÛ> M
,
ÛÛM N
nullable
ÛÛO W
:
ÛÛW X
false
ÛÛY ^
)
ÛÛ^ _
,
ÛÛ_ `
UserId
ÜÜ 
=
ÜÜ 
table
ÜÜ "
.
ÜÜ" #
Column
ÜÜ# )
<
ÜÜ) *
string
ÜÜ* 0
>
ÜÜ0 1
(
ÜÜ1 2
type
ÜÜ2 6
:
ÜÜ6 7
$str
ÜÜ8 G
,
ÜÜG H
nullable
ÜÜI Q
:
ÜÜQ R
false
ÜÜS X
)
ÜÜX Y
}
İİ 
,
İİ 
constraints
ŞŞ 
:
ŞŞ 
table
ŞŞ "
=>
ŞŞ# %
{
ßß 
table
àà 
.
àà 

PrimaryKey
àà $
(
àà$ %
$str
àà% 6
,
àà6 7
x
àà8 9
=>
àà: <
x
àà= >
.
àà> ?

CardNumber
àà? I
)
ààI J
;
ààJ K
table
áá 
.
áá 

ForeignKey
áá $
(
áá$ %
name
ââ 
:
ââ 
$str
ââ B
,
ââB C
column
ãã 
:
ãã 
x
ãã  !
=>
ãã" $
x
ãã% &
.
ãã& '
UserId
ãã' -
,
ãã- .
principalTable
ää &
:
ää& '
$str
ää( 5
,
ää5 6
principalColumn
åå '
:
åå' (
$str
åå) -
,
åå- .
onDelete
ææ  
:
ææ  !
ReferentialAction
ææ" 3
.
ææ3 4
Cascade
ææ4 ;
)
ææ; <
;
ææ< =
}
çç 
)
çç 
;
çç 
migrationBuilder
éé 
.
éé 
CreateTable
éé (
(
éé( )
name
êê 
:
êê 
$str
êê  
,
êê  !
columns
ëë 
:
ëë 
table
ëë 
=>
ëë !
new
ëë" %
{
ìì 
	StudentId
íí 
=
íí 
table
íí  %
.
íí% &
Column
íí& ,
<
íí, -
Guid
íí- 1
>
íí1 2
(
íí2 3
type
íí3 7
:
íí7 8
$str
íí9 K
,
ííK L
nullable
ííM U
:
ííU V
false
ííW \
)
íí\ ]
,
íí] ^
UserId
îî 
=
îî 
table
îî "
.
îî" #
Column
îî# )
<
îî) *
string
îî* 0
>
îî0 1
(
îî1 2
type
îî2 6
:
îî6 7
$str
îî8 G
,
îîG H
nullable
îîI Q
:
îîQ R
false
îîS X
)
îîX Y
,
îîY Z

University
ïï 
=
ïï  
table
ïï! &
.
ïï& '
Column
ïï' -
<
ïï- .
string
ïï. 4
>
ïï4 5
(
ïï5 6
type
ïï6 :
:
ïï: ;
$str
ïï< K
,
ïïK L
nullable
ïïM U
:
ïïU V
false
ïïW \
)
ïï\ ]
}
ğğ 
,
ğğ 
constraints
ññ 
:
ññ 
table
ññ "
=>
ññ# %
{
òò 
table
óó 
.
óó 

PrimaryKey
óó $
(
óó$ %
$str
óó% 2
,
óó2 3
x
óó4 5
=>
óó6 8
x
óó9 :
.
óó: ;
	StudentId
óó; D
)
óóD E
;
óóE F
table
ôô 
.
ôô 

ForeignKey
ôô $
(
ôô$ %
name
õõ 
:
õõ 
$str
õõ >
,
õõ> ?
column
öö 
:
öö 
x
öö  !
=>
öö" $
x
öö% &
.
öö& '
UserId
öö' -
,
öö- .
principalTable
÷÷ &
:
÷÷& '
$str
÷÷( 5
,
÷÷5 6
principalColumn
øø '
:
øø' (
$str
øø) -
,
øø- .
onDelete
ùù  
:
ùù  !
ReferentialAction
ùù" 3
.
ùù3 4
Cascade
ùù4 ;
)
ùù; <
;
ùù< =
}
úú 
)
úú 
;
úú 
migrationBuilder
üü 
.
üü 
CreateTable
üü (
(
üü( )
name
ıı 
:
ıı 
$str
ıı 
,
ıı  
columns
şş 
:
şş 
table
şş 
=>
şş !
new
şş" %
{
ÿÿ 
Id
€€ 
=
€€ 
table
€€ 
.
€€ 
Column
€€ %
<
€€% &
Guid
€€& *
>
€€* +
(
€€+ ,
type
€€, 0
:
€€0 1
$str
€€2 D
,
€€D E
nullable
€€F N
:
€€N O
false
€€P U
)
€€U V
,
€€V W
InstructorId
  
=
! "
table
# (
.
( )
Column
) /
<
/ 0
Guid
0 4
>
4 5
(
5 6
type
6 :
:
: ;
$str
< N
,
N O
nullable
P X
:
X Y
false
Z _
)
_ `
,
` a

CategoryId
‚‚ 
=
‚‚  
table
‚‚! &
.
‚‚& '
Column
‚‚' -
<
‚‚- .
Guid
‚‚. 2
>
‚‚2 3
(
‚‚3 4
type
‚‚4 8
:
‚‚8 9
$str
‚‚: L
,
‚‚L M
nullable
‚‚N V
:
‚‚V W
false
‚‚X ]
)
‚‚] ^
,
‚‚^ _
LevelId
ƒƒ 
=
ƒƒ 
table
ƒƒ #
.
ƒƒ# $
Column
ƒƒ$ *
<
ƒƒ* +
Guid
ƒƒ+ /
>
ƒƒ/ 0
(
ƒƒ0 1
type
ƒƒ1 5
:
ƒƒ5 6
$str
ƒƒ7 I
,
ƒƒI J
nullable
ƒƒK S
:
ƒƒS T
false
ƒƒU Z
)
ƒƒZ [
,
ƒƒ[ \
CreateAt
„„ 
=
„„ 
table
„„ $
.
„„$ %
Column
„„% +
<
„„+ ,
DateTime
„„, 4
>
„„4 5
(
„„5 6
type
„„6 :
:
„„: ;
$str
„„< G
,
„„G H
nullable
„„I Q
:
„„Q R
false
„„S X
)
„„X Y
,
„„Y Z
StudentSlot
…… 
=
……  !
table
……" '
.
……' (
Column
……( .
<
……. /
int
……/ 2
>
……2 3
(
……3 4
type
……4 8
:
……8 9
$str
……: ?
,
……? @
nullable
……A I
:
……I J
false
……K P
)
……P Q
,
……Q R
LearningTime
††  
=
††! "
table
††# (
.
††( )
Column
††) /
<
††/ 0
DateTime
††0 8
>
††8 9
(
††9 :
type
††: >
:
††> ?
$str
††@ K
,
††K L
nullable
††M U
:
††U V
false
††W \
)
††\ ]
,
††] ^
Price
‡‡ 
=
‡‡ 
table
‡‡ !
.
‡‡! "
Column
‡‡" (
<
‡‡( )
double
‡‡) /
>
‡‡/ 0
(
‡‡0 1
type
‡‡1 5
:
‡‡5 6
$str
‡‡7 >
,
‡‡> ?
nullable
‡‡@ H
:
‡‡H I
false
‡‡J O
)
‡‡O P
,
‡‡P Q
CourseImgUrl
ˆˆ  
=
ˆˆ! "
table
ˆˆ# (
.
ˆˆ( )
Column
ˆˆ) /
<
ˆˆ/ 0
string
ˆˆ0 6
>
ˆˆ6 7
(
ˆˆ7 8
type
ˆˆ8 <
:
ˆˆ< =
$str
ˆˆ> M
,
ˆˆM N
nullable
ˆˆO W
:
ˆˆW X
true
ˆˆY ]
)
ˆˆ] ^
,
ˆˆ^ _
Title
‰‰ 
=
‰‰ 
table
‰‰ !
.
‰‰! "
Column
‰‰" (
<
‰‰( )
string
‰‰) /
>
‰‰/ 0
(
‰‰0 1
type
‰‰1 5
:
‰‰5 6
$str
‰‰7 F
,
‰‰F G
nullable
‰‰H P
:
‰‰P Q
false
‰‰R W
)
‰‰W X
,
‰‰X Y
Description
ŠŠ 
=
ŠŠ  !
table
ŠŠ" '
.
ŠŠ' (
Column
ŠŠ( .
<
ŠŠ. /
string
ŠŠ/ 5
>
ŠŠ5 6
(
ŠŠ6 7
type
ŠŠ7 ;
:
ŠŠ; <
$str
ŠŠ= L
,
ŠŠL M
nullable
ŠŠN V
:
ŠŠV W
false
ŠŠX ]
)
ŠŠ] ^
,
ŠŠ^ _

IsAccepted
‹‹ 
=
‹‹  
table
‹‹! &
.
‹‹& '
Column
‹‹' -
<
‹‹- .
bool
‹‹. 2
>
‹‹2 3
(
‹‹3 4
type
‹‹4 8
:
‹‹8 9
$str
‹‹: ?
,
‹‹? @
nullable
‹‹A I
:
‹‹I J
false
‹‹K P
)
‹‹P Q
,
‹‹Q R
IsDelete
ŒŒ 
=
ŒŒ 
table
ŒŒ $
.
ŒŒ$ %
Column
ŒŒ% +
<
ŒŒ+ ,
bool
ŒŒ, 0
>
ŒŒ0 1
(
ŒŒ1 2
type
ŒŒ2 6
:
ŒŒ6 7
$str
ŒŒ8 =
,
ŒŒ= >
nullable
ŒŒ? G
:
ŒŒG H
false
ŒŒI N
)
ŒŒN O
,
ŒŒO P
	TotalRate
 
=
 
table
  %
.
% &
Column
& ,
<
, -
float
- 2
>
2 3
(
3 4
type
4 8
:
8 9
$str
: @
,
@ A
nullable
B J
:
J K
false
L Q
)
Q R
}
 
,
 
constraints
 
:
 
table
 "
=>
# %
{
 
table
‘‘ 
.
‘‘ 

PrimaryKey
‘‘ $
(
‘‘$ %
$str
‘‘% 1
,
‘‘1 2
x
‘‘3 4
=>
‘‘5 7
x
‘‘8 9
.
‘‘9 :
Id
‘‘: <
)
‘‘< =
;
‘‘= >
table
’’ 
.
’’ 

ForeignKey
’’ $
(
’’$ %
name
““ 
:
““ 
$str
““ @
,
““@ A
column
”” 
:
”” 
x
””  !
=>
””" $
x
””% &
.
””& '

CategoryId
””' 1
,
””1 2
principalTable
•• &
:
••& '
$str
••( 4
,
••4 5
principalColumn
–– '
:
––' (
$str
––) -
,
––- .
onDelete
——  
:
——  !
ReferentialAction
——" 3
.
——3 4
Cascade
——4 ;
)
——; <
;
——< =
table
˜˜ 
.
˜˜ 

ForeignKey
˜˜ $
(
˜˜$ %
name
™™ 
:
™™ 
$str
™™ C
,
™™C D
column
šš 
:
šš 
x
šš  !
=>
šš" $
x
šš% &
.
šš& '
InstructorId
šš' 3
,
šš3 4
principalTable
›› &
:
››& '
$str
››( 5
,
››5 6
principalColumn
œœ '
:
œœ' (
$str
œœ) 7
,
œœ7 8
onDelete
  
:
  !
ReferentialAction
" 3
.
3 4
Cascade
4 ;
)
; <
;
< =
table
 
.
 

ForeignKey
 $
(
$ %
name
ŸŸ 
:
ŸŸ 
$str
ŸŸ 9
,
ŸŸ9 :
column
   
:
   
x
    !
=>
  " $
x
  % &
.
  & '
LevelId
  ' .
,
  . /
principalTable
¡¡ &
:
¡¡& '
$str
¡¡( 0
,
¡¡0 1
principalColumn
¢¢ '
:
¢¢' (
$str
¢¢) -
,
¢¢- .
onDelete
££  
:
££  !
ReferentialAction
££" 3
.
££3 4
Cascade
££4 ;
)
££; <
;
££< =
}
¤¤ 
)
¤¤ 
;
¤¤ 
migrationBuilder
¦¦ 
.
¦¦ 
CreateTable
¦¦ (
(
¦¦( )
name
§§ 
:
§§ 
$str
§§ #
,
§§# $
columns
¨¨ 
:
¨¨ 
table
¨¨ 
=>
¨¨ !
new
¨¨" %
{
©© 
Id
ªª 
=
ªª 
table
ªª 
.
ªª 
Column
ªª %
<
ªª% &
Guid
ªª& *
>
ªª* +
(
ªª+ ,
type
ªª, 0
:
ªª0 1
$str
ªª2 D
,
ªªD E
nullable
ªªF N
:
ªªN O
false
ªªP U
)
ªªU V
,
ªªV W
	StudentId
«« 
=
«« 
table
««  %
.
««% &
Column
««& ,
<
««, -
Guid
««- 1
>
««1 2
(
««2 3
type
««3 7
:
««7 8
$str
««9 K
,
««K L
nullable
««M U
:
««U V
false
««W \
)
««\ ]
,
««] ^

TotalPrice
¬¬ 
=
¬¬  
table
¬¬! &
.
¬¬& '
Column
¬¬' -
<
¬¬- .
double
¬¬. 4
>
¬¬4 5
(
¬¬5 6
type
¬¬6 :
:
¬¬: ;
$str
¬¬< C
,
¬¬C D
nullable
¬¬E M
:
¬¬M N
false
¬¬O T
)
¬¬T U
}
­­ 
,
­­ 
constraints
®® 
:
®® 
table
®® "
=>
®®# %
{
¯¯ 
table
°° 
.
°° 

PrimaryKey
°° $
(
°°$ %
$str
°°% 5
,
°°5 6
x
°°7 8
=>
°°9 ;
x
°°< =
.
°°= >
Id
°°> @
)
°°@ A
;
°°A B
table
±± 
.
±± 

ForeignKey
±± $
(
±±$ %
name
²² 
:
²² 
$str
²² A
,
²²A B
column
³³ 
:
³³ 
x
³³  !
=>
³³" $
x
³³% &
.
³³& '
	StudentId
³³' 0
,
³³0 1
principalTable
´´ &
:
´´& '
$str
´´( 2
,
´´2 3
principalColumn
µµ '
:
µµ' (
$str
µµ) 4
,
µµ4 5
onDelete
¶¶  
:
¶¶  !
ReferentialAction
¶¶" 3
.
¶¶3 4
Cascade
¶¶4 ;
)
¶¶; <
;
¶¶< =
}
·· 
)
·· 
;
·· 
migrationBuilder
¹¹ 
.
¹¹ 
CreateTable
¹¹ (
(
¹¹( )
name
ºº 
:
ºº 
$str
ºº $
,
ºº$ %
columns
»» 
:
»» 
table
»» 
=>
»» !
new
»»" %
{
¼¼ 
Id
½½ 
=
½½ 
table
½½ 
.
½½ 
Column
½½ %
<
½½% &
Guid
½½& *
>
½½* +
(
½½+ ,
type
½½, 0
:
½½0 1
$str
½½2 D
,
½½D E
nullable
½½F N
:
½½N O
false
½½P U
)
½½U V
,
½½V W
	StudentId
¾¾ 
=
¾¾ 
table
¾¾  %
.
¾¾% &
Column
¾¾& ,
<
¾¾, -
Guid
¾¾- 1
>
¾¾1 2
(
¾¾2 3
type
¾¾3 7
:
¾¾7 8
$str
¾¾9 K
,
¾¾K L
nullable
¾¾M U
:
¾¾U V
false
¾¾W \
)
¾¾\ ]
,
¾¾] ^
CreateAt
¿¿ 
=
¿¿ 
table
¿¿ $
.
¿¿$ %
Column
¿¿% +
<
¿¿+ ,
DateTime
¿¿, 4
>
¿¿4 5
(
¿¿5 6
type
¿¿6 :
:
¿¿: ;
$str
¿¿< G
,
¿¿G H
nullable
¿¿I Q
:
¿¿Q R
false
¿¿S X
)
¿¿X Y
,
¿¿Y Z

OrderPrice
ÀÀ 
=
ÀÀ  
table
ÀÀ! &
.
ÀÀ& '
Column
ÀÀ' -
<
ÀÀ- .
double
ÀÀ. 4
>
ÀÀ4 5
(
ÀÀ5 6
type
ÀÀ6 :
:
ÀÀ: ;
$str
ÀÀ< C
,
ÀÀC D
nullable
ÀÀE M
:
ÀÀM N
false
ÀÀO T
)
ÀÀT U
,
ÀÀU V
IsPayout
ÁÁ 
=
ÁÁ 
table
ÁÁ $
.
ÁÁ$ %
Column
ÁÁ% +
<
ÁÁ+ ,
bool
ÁÁ, 0
>
ÁÁ0 1
(
ÁÁ1 2
type
ÁÁ2 6
:
ÁÁ6 7
$str
ÁÁ8 =
,
ÁÁ= >
nullable
ÁÁ? G
:
ÁÁG H
false
ÁÁI N
)
ÁÁN O
,
ÁÁO P
	IsSuccess
ÂÂ 
=
ÂÂ 
table
ÂÂ  %
.
ÂÂ% &
Column
ÂÂ& ,
<
ÂÂ, -
bool
ÂÂ- 1
>
ÂÂ1 2
(
ÂÂ2 3
type
ÂÂ3 7
:
ÂÂ7 8
$str
ÂÂ9 >
,
ÂÂ> ?
nullable
ÂÂ@ H
:
ÂÂH I
false
ÂÂJ O
)
ÂÂO P
}
ÃÃ 
,
ÃÃ 
constraints
ÄÄ 
:
ÄÄ 
table
ÄÄ "
=>
ÄÄ# %
{
ÅÅ 
table
ÆÆ 
.
ÆÆ 

PrimaryKey
ÆÆ $
(
ÆÆ$ %
$str
ÆÆ% 6
,
ÆÆ6 7
x
ÆÆ8 9
=>
ÆÆ: <
x
ÆÆ= >
.
ÆÆ> ?
Id
ÆÆ? A
)
ÆÆA B
;
ÆÆB C
table
ÇÇ 
.
ÇÇ 

ForeignKey
ÇÇ $
(
ÇÇ$ %
name
ÈÈ 
:
ÈÈ 
$str
ÈÈ B
,
ÈÈB C
column
ÉÉ 
:
ÉÉ 
x
ÉÉ  !
=>
ÉÉ" $
x
ÉÉ% &
.
ÉÉ& '
	StudentId
ÉÉ' 0
,
ÉÉ0 1
principalTable
ÊÊ &
:
ÊÊ& '
$str
ÊÊ( 2
,
ÊÊ2 3
principalColumn
ËË '
:
ËË' (
$str
ËË) 4
,
ËË4 5
onDelete
ÌÌ  
:
ÌÌ  !
ReferentialAction
ÌÌ" 3
.
ÌÌ3 4
Cascade
ÌÌ4 ;
)
ÌÌ; <
;
ÌÌ< =
}
ÍÍ 
)
ÍÍ 
;
ÍÍ 
migrationBuilder
ÏÏ 
.
ÏÏ 
CreateTable
ÏÏ (
(
ÏÏ( )
name
ĞĞ 
:
ĞĞ 
$str
ĞĞ %
,
ĞĞ% &
columns
ÑÑ 
:
ÑÑ 
table
ÑÑ 
=>
ÑÑ !
new
ÑÑ" %
{
ÒÒ 
Id
ÓÓ 
=
ÓÓ 
table
ÓÓ 
.
ÓÓ 
Column
ÓÓ %
<
ÓÓ% &
Guid
ÓÓ& *
>
ÓÓ* +
(
ÓÓ+ ,
type
ÓÓ, 0
:
ÓÓ0 1
$str
ÓÓ2 D
,
ÓÓD E
nullable
ÓÓF N
:
ÓÓN O
false
ÓÓP U
)
ÓÓU V
,
ÓÓV W
	StudentId
ÔÔ 
=
ÔÔ 
table
ÔÔ  %
.
ÔÔ% &
Column
ÔÔ& ,
<
ÔÔ, -
Guid
ÔÔ- 1
>
ÔÔ1 2
(
ÔÔ2 3
type
ÔÔ3 7
:
ÔÔ7 8
$str
ÔÔ9 K
,
ÔÔK L
nullable
ÔÔM U
:
ÔÔU V
false
ÔÔW \
)
ÔÔ\ ]
,
ÔÔ] ^
CourseId
ÕÕ 
=
ÕÕ 
table
ÕÕ $
.
ÕÕ$ %
Column
ÕÕ% +
<
ÕÕ+ ,
Guid
ÕÕ, 0
>
ÕÕ0 1
(
ÕÕ1 2
type
ÕÕ2 6
:
ÕÕ6 7
$str
ÕÕ8 J
,
ÕÕJ K
nullable
ÕÕL T
:
ÕÕT U
false
ÕÕV [
)
ÕÕ[ \
,
ÕÕ\ ]
CreateAt
ÖÖ 
=
ÖÖ 
table
ÖÖ $
.
ÖÖ$ %
Column
ÖÖ% +
<
ÖÖ+ ,
DateTime
ÖÖ, 4
>
ÖÖ4 5
(
ÖÖ5 6
type
ÖÖ6 :
:
ÖÖ: ;
$str
ÖÖ< G
,
ÖÖG H
nullable
ÖÖI Q
:
ÖÖQ R
false
ÖÖS X
)
ÖÖX Y
,
ÖÖY Z
Message
×× 
=
×× 
table
×× #
.
××# $
Column
××$ *
<
××* +
string
××+ 1
>
××1 2
(
××2 3
type
××3 7
:
××7 8
$str
××9 H
,
××H I
nullable
××J R
:
××R S
false
××T Y
)
××Y Z
,
××Z [
IsSent
ØØ 
=
ØØ 
table
ØØ "
.
ØØ" #
Column
ØØ# )
<
ØØ) *
bool
ØØ* .
>
ØØ. /
(
ØØ/ 0
type
ØØ0 4
:
ØØ4 5
$str
ØØ6 ;
,
ØØ; <
nullable
ØØ= E
:
ØØE F
false
ØØG L
)
ØØL M
,
ØØM N

IsAccepted
ÙÙ 
=
ÙÙ  
table
ÙÙ! &
.
ÙÙ& '
Column
ÙÙ' -
<
ÙÙ- .
bool
ÙÙ. 2
>
ÙÙ2 3
(
ÙÙ3 4
type
ÙÙ4 8
:
ÙÙ8 9
$str
ÙÙ: ?
,
ÙÙ? @
nullable
ÙÙA I
:
ÙÙI J
false
ÙÙK P
)
ÙÙP Q
}
ÚÚ 
,
ÚÚ 
constraints
ÛÛ 
:
ÛÛ 
table
ÛÛ "
=>
ÛÛ# %
{
ÜÜ 
table
İİ 
.
İİ 

PrimaryKey
İİ $
(
İİ$ %
$str
İİ% 7
,
İİ7 8
x
İİ9 :
=>
İİ; =
x
İİ> ?
.
İİ? @
Id
İİ@ B
)
İİB C
;
İİC D
table
ŞŞ 
.
ŞŞ 

ForeignKey
ŞŞ $
(
ŞŞ$ %
name
ßß 
:
ßß 
$str
ßß A
,
ßßA B
column
àà 
:
àà 
x
àà  !
=>
àà" $
x
àà% &
.
àà& '
CourseId
àà' /
,
àà/ 0
principalTable
áá &
:
áá& '
$str
áá( 1
,
áá1 2
principalColumn
ââ '
:
ââ' (
$str
ââ) -
,
ââ- .
onDelete
ãã  
:
ãã  !
ReferentialAction
ãã" 3
.
ãã3 4
Cascade
ãã4 ;
)
ãã; <
;
ãã< =
}
ää 
)
ää 
;
ää 
migrationBuilder
ææ 
.
ææ 
CreateTable
ææ (
(
ææ( )
name
çç 
:
çç 
$str
çç %
,
çç% &
columns
èè 
:
èè 
table
èè 
=>
èè !
new
èè" %
{
éé 
Id
êê 
=
êê 
table
êê 
.
êê 
Column
êê %
<
êê% &
Guid
êê& *
>
êê* +
(
êê+ ,
type
êê, 0
:
êê0 1
$str
êê2 D
,
êêD E
nullable
êêF N
:
êêN O
false
êêP U
)
êêU V
,
êêV W
	StudentId
ëë 
=
ëë 
table
ëë  %
.
ëë% &
Column
ëë& ,
<
ëë, -
Guid
ëë- 1
>
ëë1 2
(
ëë2 3
type
ëë3 7
:
ëë7 8
$str
ëë9 K
,
ëëK L
nullable
ëëM U
:
ëëU V
false
ëëW \
)
ëë\ ]
,
ëë] ^
CourseId
ìì 
=
ìì 
table
ìì $
.
ìì$ %
Column
ìì% +
<
ìì+ ,
Guid
ìì, 0
>
ìì0 1
(
ìì1 2
type
ìì2 6
:
ìì6 7
$str
ìì8 J
,
ììJ K
nullable
ììL T
:
ììT U
false
ììV [
)
ìì[ \
,
ìì\ ]
Rate
íí 
=
íí 
table
íí  
.
íí  !
Column
íí! '
<
íí' (
float
íí( -
>
íí- .
(
íí. /
type
íí/ 3
:
íí3 4
$str
íí5 ;
,
íí; <
nullable
íí= E
:
ííE F
false
ííG L
)
ííL M
,
ííM N
Message
îî 
=
îî 
table
îî #
.
îî# $
Column
îî$ *
<
îî* +
string
îî+ 1
>
îî1 2
(
îî2 3
type
îî3 7
:
îî7 8
$str
îî9 H
,
îîH I
nullable
îîJ R
:
îîR S
false
îîT Y
)
îîY Z
,
îîZ [
CreateAt
ïï 
=
ïï 
table
ïï $
.
ïï$ %
Column
ïï% +
<
ïï+ ,
DateTime
ïï, 4
>
ïï4 5
(
ïï5 6
type
ïï6 :
:
ïï: ;
$str
ïï< G
,
ïïG H
nullable
ïïI Q
:
ïïQ R
false
ïïS X
)
ïïX Y
,
ïïY Z
IsDelete
ğğ 
=
ğğ 
table
ğğ $
.
ğğ$ %
Column
ğğ% +
<
ğğ+ ,
bool
ğğ, 0
>
ğğ0 1
(
ğğ1 2
type
ğğ2 6
:
ğğ6 7
$str
ğğ8 =
,
ğğ= >
nullable
ğğ? G
:
ğğG H
false
ğğI N
)
ğğN O
}
ññ 
,
ññ 
constraints
òò 
:
òò 
table
òò "
=>
òò# %
{
óó 
table
ôô 
.
ôô 

PrimaryKey
ôô $
(
ôô$ %
$str
ôô% 7
,
ôô7 8
x
ôô9 :
=>
ôô; =
x
ôô> ?
.
ôô? @
Id
ôô@ B
)
ôôB C
;
ôôC D
table
õõ 
.
õõ 

ForeignKey
õõ $
(
õõ$ %
name
öö 
:
öö 
$str
öö A
,
ööA B
column
÷÷ 
:
÷÷ 
x
÷÷  !
=>
÷÷" $
x
÷÷% &
.
÷÷& '
CourseId
÷÷' /
,
÷÷/ 0
principalTable
øø &
:
øø& '
$str
øø( 1
,
øø1 2
principalColumn
ùù '
:
ùù' (
$str
ùù) -
,
ùù- .
onDelete
úú  
:
úú  !
ReferentialAction
úú" 3
.
úú3 4
Cascade
úú4 ;
)
úú; <
;
úú< =
}
ûû 
)
ûû 
;
ûû 
migrationBuilder
ıı 
.
ıı 
CreateTable
ıı (
(
ıı( )
name
şş 
:
şş 
$str
şş &
,
şş& '
columns
ÿÿ 
:
ÿÿ 
table
ÿÿ 
=>
ÿÿ !
new
ÿÿ" %
{
€€ 
Id
 
=
 
table
 
.
 
Column
 %
<
% &
Guid
& *
>
* +
(
+ ,
type
, 0
:
0 1
$str
2 D
,
D E
nullable
F N
:
N O
false
P U
)
U V
,
V W
CourseId
‚‚ 
=
‚‚ 
table
‚‚ $
.
‚‚$ %
Column
‚‚% +
<
‚‚+ ,
Guid
‚‚, 0
>
‚‚0 1
(
‚‚1 2
type
‚‚2 6
:
‚‚6 7
$str
‚‚8 J
,
‚‚J K
nullable
‚‚L T
:
‚‚T U
false
‚‚V [
)
‚‚[ \
,
‚‚\ ]
Title
ƒƒ 
=
ƒƒ 
table
ƒƒ !
.
ƒƒ! "
Column
ƒƒ" (
<
ƒƒ( )
string
ƒƒ) /
>
ƒƒ/ 0
(
ƒƒ0 1
type
ƒƒ1 5
:
ƒƒ5 6
$str
ƒƒ7 F
,
ƒƒF G
nullable
ƒƒH P
:
ƒƒP Q
false
ƒƒR W
)
ƒƒW X
,
ƒƒX Y
Description
„„ 
=
„„  !
table
„„" '
.
„„' (
Column
„„( .
<
„„. /
string
„„/ 5
>
„„5 6
(
„„6 7
type
„„7 ;
:
„„; <
$str
„„= L
,
„„L M
nullable
„„N V
:
„„V W
false
„„X ]
)
„„] ^
}
…… 
,
…… 
constraints
†† 
:
†† 
table
†† "
=>
††# %
{
‡‡ 
table
ˆˆ 
.
ˆˆ 

PrimaryKey
ˆˆ $
(
ˆˆ$ %
$str
ˆˆ% 8
,
ˆˆ8 9
x
ˆˆ: ;
=>
ˆˆ< >
x
ˆˆ? @
.
ˆˆ@ A
Id
ˆˆA C
)
ˆˆC D
;
ˆˆD E
table
‰‰ 
.
‰‰ 

ForeignKey
‰‰ $
(
‰‰$ %
name
ŠŠ 
:
ŠŠ 
$str
ŠŠ B
,
ŠŠB C
column
‹‹ 
:
‹‹ 
x
‹‹  !
=>
‹‹" $
x
‹‹% &
.
‹‹& '
CourseId
‹‹' /
,
‹‹/ 0
principalTable
ŒŒ &
:
ŒŒ& '
$str
ŒŒ( 1
,
ŒŒ1 2
principalColumn
 '
:
' (
$str
) -
,
- .
onDelete
  
:
  !
ReferentialAction
" 3
.
3 4
Cascade
4 ;
)
; <
;
< =
}
 
)
 
;
 
migrationBuilder
‘‘ 
.
‘‘ 
CreateTable
‘‘ (
(
‘‘( )
name
’’ 
:
’’ 
$str
’’ &
,
’’& '
columns
““ 
:
““ 
table
““ 
=>
““ !
new
““" %
{
”” 
Id
•• 
=
•• 
table
•• 
.
•• 
Column
•• %
<
••% &
Guid
••& *
>
••* +
(
••+ ,
type
••, 0
:
••0 1
$str
••2 D
,
••D E
nullable
••F N
:
••N O
false
••P U
)
••U V
,
••V W
	StudentId
–– 
=
–– 
table
––  %
.
––% &
Column
––& ,
<
––, -
Guid
––- 1
>
––1 2
(
––2 3
type
––3 7
:
––7 8
$str
––9 K
,
––K L
nullable
––M U
:
––U V
true
––W [
)
––[ \
,
––\ ]
CourseId
—— 
=
—— 
table
—— $
.
——$ %
Column
——% +
<
——+ ,
Guid
——, 0
>
——0 1
(
——1 2
type
——2 6
:
——6 7
$str
——8 J
,
——J K
nullable
——L T
:
——T U
true
——V Z
)
——Z [
,
——[ \
LearningTime
˜˜  
=
˜˜! "
table
˜˜# (
.
˜˜( )
Column
˜˜) /
<
˜˜/ 0
DateTime
˜˜0 8
>
˜˜8 9
(
˜˜9 :
type
˜˜: >
:
˜˜> ?
$str
˜˜@ K
,
˜˜K L
nullable
˜˜M U
:
˜˜U V
false
˜˜W \
)
˜˜\ ]
,
˜˜] ^
StartAt
™™ 
=
™™ 
table
™™ #
.
™™# $
Column
™™$ *
<
™™* +
DateTime
™™+ 3
>
™™3 4
(
™™4 5
type
™™5 9
:
™™9 :
$str
™™; F
,
™™F G
nullable
™™H P
:
™™P Q
false
™™R W
)
™™W X
,
™™X Y
EndAt
šš 
=
šš 
table
šš !
.
šš! "
Column
šš" (
<
šš( )
DateTime
šš) 1
>
šš1 2
(
šš2 3
type
šš3 7
:
šš7 8
$str
šš9 D
,
ššD E
nullable
ššF N
:
ššN O
false
ššP U
)
ššU V
,
ššV W
CertificateImgUrl
›› %
=
››& '
table
››( -
.
››- .
Column
››. 4
<
››4 5
string
››5 ;
>
››; <
(
››< =
type
››= A
:
››A B
$str
››C R
,
››R S
nullable
››T \
:
››\ ]
false
››^ c
)
››c d
,
››d e
	IsSuccess
œœ 
=
œœ 
table
œœ  %
.
œœ% &
Column
œœ& ,
<
œœ, -
bool
œœ- 1
>
œœ1 2
(
œœ2 3
type
œœ3 7
:
œœ7 8
$str
œœ9 >
,
œœ> ?
nullable
œœ@ H
:
œœH I
false
œœJ O
)
œœO P
,
œœP Q

IsExpelled
 
=
  
table
! &
.
& '
Column
' -
<
- .
bool
. 2
>
2 3
(
3 4
type
4 8
:
8 9
$str
: ?
,
? @
nullable
A I
:
I J
false
K P
)
P Q
}
 
,
 
constraints
ŸŸ 
:
ŸŸ 
table
ŸŸ "
=>
ŸŸ# %
{
   
table
¡¡ 
.
¡¡ 

PrimaryKey
¡¡ $
(
¡¡$ %
$str
¡¡% 8
,
¡¡8 9
x
¡¡: ;
=>
¡¡< >
x
¡¡? @
.
¡¡@ A
Id
¡¡A C
)
¡¡C D
;
¡¡D E
table
¢¢ 
.
¢¢ 

ForeignKey
¢¢ $
(
¢¢$ %
name
££ 
:
££ 
$str
££ B
,
££B C
column
¤¤ 
:
¤¤ 
x
¤¤  !
=>
¤¤" $
x
¤¤% &
.
¤¤& '
CourseId
¤¤' /
,
¤¤/ 0
principalTable
¥¥ &
:
¥¥& '
$str
¥¥( 1
,
¥¥1 2
principalColumn
¦¦ '
:
¦¦' (
$str
¦¦) -
)
¦¦- .
;
¦¦. /
table
§§ 
.
§§ 

ForeignKey
§§ $
(
§§$ %
name
¨¨ 
:
¨¨ 
$str
¨¨ D
,
¨¨D E
column
©© 
:
©© 
x
©©  !
=>
©©" $
x
©©% &
.
©©& '
	StudentId
©©' 0
,
©©0 1
principalTable
ªª &
:
ªª& '
$str
ªª( 2
,
ªª2 3
principalColumn
«« '
:
««' (
$str
««) 4
)
««4 5
;
««5 6
}
¬¬ 
)
¬¬ 
;
¬¬ 
migrationBuilder
®® 
.
®® 
CreateTable
®® (
(
®®( )
name
¯¯ 
:
¯¯ 
$str
¯¯ #
,
¯¯# $
columns
°° 
:
°° 
table
°° 
=>
°° !
new
°°" %
{
±± 
Id
²² 
=
²² 
table
²² 
.
²² 
Column
²² %
<
²²% &
Guid
²²& *
>
²²* +
(
²²+ ,
type
²², 0
:
²²0 1
$str
²²2 D
,
²²D E
nullable
²²F N
:
²²N O
false
²²P U
)
²²U V
,
²²V W
CartHeaderId
³³  
=
³³! "
table
³³# (
.
³³( )
Column
³³) /
<
³³/ 0
Guid
³³0 4
>
³³4 5
(
³³5 6
type
³³6 :
:
³³: ;
$str
³³< N
,
³³N O
nullable
³³P X
:
³³X Y
false
³³Z _
)
³³_ `
,
³³` a
CourseId
´´ 
=
´´ 
table
´´ $
.
´´$ %
Column
´´% +
<
´´+ ,
Guid
´´, 0
>
´´0 1
(
´´1 2
type
´´2 6
:
´´6 7
$str
´´8 J
,
´´J K
nullable
´´L T
:
´´T U
false
´´V [
)
´´[ \
,
´´\ ]
CoursePrice
µµ 
=
µµ  !
table
µµ" '
.
µµ' (
Column
µµ( .
<
µµ. /
double
µµ/ 5
>
µµ5 6
(
µµ6 7
type
µµ7 ;
:
µµ; <
$str
µµ= D
,
µµD E
nullable
µµF N
:
µµN O
false
µµP U
)
µµU V
}
¶¶ 
,
¶¶ 
constraints
·· 
:
·· 
table
·· "
=>
··# %
{
¸¸ 
table
¹¹ 
.
¹¹ 

PrimaryKey
¹¹ $
(
¹¹$ %
$str
¹¹% 5
,
¹¹5 6
x
¹¹7 8
=>
¹¹9 ;
x
¹¹< =
.
¹¹= >
Id
¹¹> @
)
¹¹@ A
;
¹¹A B
table
ºº 
.
ºº 

ForeignKey
ºº $
(
ºº$ %
name
»» 
:
»» 
$str
»» G
,
»»G H
column
¼¼ 
:
¼¼ 
x
¼¼  !
=>
¼¼" $
x
¼¼% &
.
¼¼& '
CartHeaderId
¼¼' 3
,
¼¼3 4
principalTable
½½ &
:
½½& '
$str
½½( 5
,
½½5 6
principalColumn
¾¾ '
:
¾¾' (
$str
¾¾) -
,
¾¾- .
onDelete
¿¿  
:
¿¿  !
ReferentialAction
¿¿" 3
.
¿¿3 4
Cascade
¿¿4 ;
)
¿¿; <
;
¿¿< =
}
ÀÀ 
)
ÀÀ 
;
ÀÀ 
migrationBuilder
ÂÂ 
.
ÂÂ 
CreateTable
ÂÂ (
(
ÂÂ( )
name
ÃÃ 
:
ÃÃ 
$str
ÃÃ $
,
ÃÃ$ %
columns
ÄÄ 
:
ÄÄ 
table
ÄÄ 
=>
ÄÄ !
new
ÄÄ" %
{
ÅÅ 
Id
ÆÆ 
=
ÆÆ 
table
ÆÆ 
.
ÆÆ 
Column
ÆÆ %
<
ÆÆ% &
Guid
ÆÆ& *
>
ÆÆ* +
(
ÆÆ+ ,
type
ÆÆ, 0
:
ÆÆ0 1
$str
ÆÆ2 D
,
ÆÆD E
nullable
ÆÆF N
:
ÆÆN O
false
ÆÆP U
)
ÆÆU V
,
ÆÆV W
CourseId
ÇÇ 
=
ÇÇ 
table
ÇÇ $
.
ÇÇ$ %
Column
ÇÇ% +
<
ÇÇ+ ,
Guid
ÇÇ, 0
>
ÇÇ0 1
(
ÇÇ1 2
type
ÇÇ2 6
:
ÇÇ6 7
$str
ÇÇ8 J
,
ÇÇJ K
nullable
ÇÇL T
:
ÇÇT U
false
ÇÇV [
)
ÇÇ[ \
,
ÇÇ\ ]
CoursePrice
ÈÈ 
=
ÈÈ  !
table
ÈÈ" '
.
ÈÈ' (
Column
ÈÈ( .
<
ÈÈ. /
double
ÈÈ/ 5
>
ÈÈ5 6
(
ÈÈ6 7
type
ÈÈ7 ;
:
ÈÈ; <
$str
ÈÈ= D
,
ÈÈD E
nullable
ÈÈF N
:
ÈÈN O
false
ÈÈP U
)
ÈÈU V
,
ÈÈV W
OrderHeaderId
ÉÉ !
=
ÉÉ" #
table
ÉÉ$ )
.
ÉÉ) *
Column
ÉÉ* 0
<
ÉÉ0 1
Guid
ÉÉ1 5
>
ÉÉ5 6
(
ÉÉ6 7
type
ÉÉ7 ;
:
ÉÉ; <
$str
ÉÉ= O
,
ÉÉO P
nullable
ÉÉQ Y
:
ÉÉY Z
false
ÉÉ[ `
)
ÉÉ` a
}
ÊÊ 
,
ÊÊ 
constraints
ËË 
:
ËË 
table
ËË "
=>
ËË# %
{
ÌÌ 
table
ÍÍ 
.
ÍÍ 

PrimaryKey
ÍÍ $
(
ÍÍ$ %
$str
ÍÍ% 6
,
ÍÍ6 7
x
ÍÍ8 9
=>
ÍÍ: <
x
ÍÍ= >
.
ÍÍ> ?
Id
ÍÍ? A
)
ÍÍA B
;
ÍÍB C
table
ÎÎ 
.
ÎÎ 

ForeignKey
ÎÎ $
(
ÎÎ$ %
name
ÏÏ 
:
ÏÏ 
$str
ÏÏ J
,
ÏÏJ K
column
ĞĞ 
:
ĞĞ 
x
ĞĞ  !
=>
ĞĞ" $
x
ĞĞ% &
.
ĞĞ& '
OrderHeaderId
ĞĞ' 4
,
ĞĞ4 5
principalTable
ÑÑ &
:
ÑÑ& '
$str
ÑÑ( 6
,
ÑÑ6 7
principalColumn
ÒÒ '
:
ÒÒ' (
$str
ÒÒ) -
,
ÒÒ- .
onDelete
ÓÓ  
:
ÓÓ  !
ReferentialAction
ÓÓ" 3
.
ÓÓ3 4
Cascade
ÓÓ4 ;
)
ÓÓ; <
;
ÓÓ< =
}
ÔÔ 
)
ÔÔ 
;
ÔÔ 
migrationBuilder
ÖÖ 
.
ÖÖ 
CreateTable
ÖÖ (
(
ÖÖ( )
name
×× 
:
×× 
$str
×× &
,
××& '
columns
ØØ 
:
ØØ 
table
ØØ 
=>
ØØ !
new
ØØ" %
{
ÙÙ 
Id
ÚÚ 
=
ÚÚ 
table
ÚÚ 
.
ÚÚ 
Column
ÚÚ %
<
ÚÚ% &
Guid
ÚÚ& *
>
ÚÚ* +
(
ÚÚ+ ,
type
ÚÚ, 0
:
ÚÚ0 1
$str
ÚÚ2 D
,
ÚÚD E
nullable
ÚÚF N
:
ÚÚN O
false
ÚÚP U
)
ÚÚU V
,
ÚÚV W
CourseSectionId
ÛÛ #
=
ÛÛ$ %
table
ÛÛ& +
.
ÛÛ+ ,
Column
ÛÛ, 2
<
ÛÛ2 3
Guid
ÛÛ3 7
>
ÛÛ7 8
(
ÛÛ8 9
type
ÛÛ9 =
:
ÛÛ= >
$str
ÛÛ? Q
,
ÛÛQ R
nullable
ÛÛS [
:
ÛÛ[ \
false
ÛÛ] b
)
ÛÛb c
,
ÛÛc d
Name
ÜÜ 
=
ÜÜ 
table
ÜÜ  
.
ÜÜ  !
Column
ÜÜ! '
<
ÜÜ' (
string
ÜÜ( .
>
ÜÜ. /
(
ÜÜ/ 0
type
ÜÜ0 4
:
ÜÜ4 5
$str
ÜÜ6 E
,
ÜÜE F
nullable
ÜÜG O
:
ÜÜO P
false
ÜÜQ V
)
ÜÜV W
,
ÜÜW X
VideoUrl
İİ 
=
İİ 
table
İİ $
.
İİ$ %
Column
İİ% +
<
İİ+ ,
string
İİ, 2
>
İİ2 3
(
İİ3 4
type
İİ4 8
:
İİ8 9
$str
İİ: I
,
İİI J
nullable
İİK S
:
İİS T
false
İİU Z
)
İİZ [
}
ŞŞ 
,
ŞŞ 
constraints
ßß 
:
ßß 
table
ßß "
=>
ßß# %
{
àà 
table
áá 
.
áá 

PrimaryKey
áá $
(
áá$ %
$str
áá% 8
,
áá8 9
x
áá: ;
=>
áá< >
x
áá? @
.
áá@ A
Id
ááA C
)
ááC D
;
ááD E
table
ââ 
.
ââ 

ForeignKey
ââ $
(
ââ$ %
name
ãã 
:
ãã 
$str
ãã P
,
ããP Q
column
ää 
:
ää 
x
ää  !
=>
ää" $
x
ää% &
.
ää& '
CourseSectionId
ää' 6
,
ää6 7
principalTable
åå &
:
åå& '
$str
åå( 8
,
åå8 9
principalColumn
ææ '
:
ææ' (
$str
ææ) -
,
ææ- .
onDelete
çç  
:
çç  !
ReferentialAction
çç" 3
.
çç3 4
Cascade
çç4 ;
)
çç; <
;
çç< =
}
èè 
)
èè 
;
èè 
migrationBuilder
êê 
.
êê 
CreateIndex
êê (
(
êê( )
name
ëë 
:
ëë 
$str
ëë 2
,
ëë2 3
table
ìì 
:
ìì 
$str
ìì )
,
ìì) *
column
íí 
:
íí 
$str
íí  
)
íí  !
;
íí! "
migrationBuilder
ïï 
.
ïï 
CreateIndex
ïï (
(
ïï( )
name
ğğ 
:
ğğ 
$str
ğğ %
,
ğğ% &
table
ññ 
:
ññ 
$str
ññ $
,
ññ$ %
column
òò 
:
òò 
$str
òò (
,
òò( )
unique
óó 
:
óó 
true
óó 
,
óó 
filter
ôô 
:
ôô 
$str
ôô 6
)
ôô6 7
;
ôô7 8
migrationBuilder
öö 
.
öö 
CreateIndex
öö (
(
öö( )
name
÷÷ 
:
÷÷ 
$str
÷÷ 2
,
÷÷2 3
table
øø 
:
øø 
$str
øø )
,
øø) *
column
ùù 
:
ùù 
$str
ùù  
)
ùù  !
;
ùù! "
migrationBuilder
ûû 
.
ûû 
CreateIndex
ûû (
(
ûû( )
name
üü 
:
üü 
$str
üü 2
,
üü2 3
table
ıı 
:
ıı 
$str
ıı )
,
ıı) *
column
şş 
:
şş 
$str
şş  
)
şş  !
;
şş! "
migrationBuilder
€€ 
.
€€ 
CreateIndex
€€ (
(
€€( )
name
 
:
 
$str
 1
,
1 2
table
‚‚ 
:
‚‚ 
$str
‚‚ (
,
‚‚( )
column
ƒƒ 
:
ƒƒ 
$str
ƒƒ  
)
ƒƒ  !
;
ƒƒ! "
migrationBuilder
…… 
.
…… 
CreateIndex
…… (
(
……( )
name
†† 
:
†† 
$str
†† "
,
††" #
table
‡‡ 
:
‡‡ 
$str
‡‡ $
,
‡‡$ %
column
ˆˆ 
:
ˆˆ 
$str
ˆˆ )
)
ˆˆ) *
;
ˆˆ* +
migrationBuilder
ŠŠ 
.
ŠŠ 
CreateIndex
ŠŠ (
(
ŠŠ( )
name
‹‹ 
:
‹‹ 
$str
‹‹ %
,
‹‹% &
table
ŒŒ 
:
ŒŒ 
$str
ŒŒ $
,
ŒŒ$ %
column
 
:
 
$str
 ,
,
, -
unique
 
:
 
true
 
,
 
filter
 
:
 
$str
 :
)
: ;
;
; <
migrationBuilder
‘‘ 
.
‘‘ 
CreateIndex
‘‘ (
(
‘‘( )
name
’’ 
:
’’ 
$str
’’ 3
,
’’3 4
table
““ 
:
““ 
$str
““ $
,
““$ %
column
”” 
:
”” 
$str
”” &
)
””& '
;
””' (
migrationBuilder
–– 
.
–– 
CreateIndex
–– (
(
––( )
name
—— 
:
—— 
$str
—— 0
,
——0 1
table
˜˜ 
:
˜˜ 
$str
˜˜ $
,
˜˜$ %
column
™™ 
:
™™ 
$str
™™ #
)
™™# $
;
™™$ %
migrationBuilder
›› 
.
›› 
CreateIndex
›› (
(
››( )
name
œœ 
:
œœ 
$str
œœ 1
,
œœ1 2
table
 
:
 
$str
 &
,
& '
column
 
:
 
$str
 "
)
" #
;
# $
migrationBuilder
   
.
   
CreateIndex
   (
(
  ( )
name
¡¡ 
:
¡¡ 
$str
¡¡ 1
,
¡¡1 2
table
¢¢ 
:
¢¢ 
$str
¢¢ &
,
¢¢& '
column
££ 
:
££ 
$str
££ "
)
££" #
;
££# $
migrationBuilder
¥¥ 
.
¥¥ 
CreateIndex
¥¥ (
(
¥¥( )
name
¦¦ 
:
¦¦ 
$str
¦¦ -
,
¦¦- .
table
§§ 
:
§§ 
$str
§§  
,
§§  !
column
¨¨ 
:
¨¨ 
$str
¨¨ $
)
¨¨$ %
;
¨¨% &
migrationBuilder
ªª 
.
ªª 
CreateIndex
ªª (
(
ªª( )
name
«« 
:
«« 
$str
«« /
,
««/ 0
table
¬¬ 
:
¬¬ 
$str
¬¬  
,
¬¬  !
column
­­ 
:
­­ 
$str
­­ &
)
­­& '
;
­­' (
migrationBuilder
¯¯ 
.
¯¯ 
CreateIndex
¯¯ (
(
¯¯( )
name
°° 
:
°° 
$str
°° *
,
°°* +
table
±± 
:
±± 
$str
±±  
,
±±  !
column
²² 
:
²² 
$str
²² !
)
²²! "
;
²²" #
migrationBuilder
´´ 
.
´´ 
CreateIndex
´´ (
(
´´( )
name
µµ 
:
µµ 
$str
µµ 2
,
µµ2 3
table
¶¶ 
:
¶¶ 
$str
¶¶ '
,
¶¶' (
column
·· 
:
·· 
$str
·· "
)
··" #
;
··# $
migrationBuilder
¹¹ 
.
¹¹ 
CreateIndex
¹¹ (
(
¹¹( )
name
ºº 
:
ºº 
$str
ºº -
,
ºº- .
table
»» 
:
»» 
$str
»» $
,
»»$ %
column
¼¼ 
:
¼¼ 
$str
¼¼  
)
¼¼  !
;
¼¼! "
migrationBuilder
¾¾ 
.
¾¾ 
CreateIndex
¾¾ (
(
¾¾( )
name
¿¿ 
:
¿¿ 
$str
¿¿ 5
,
¿¿5 6
table
ÀÀ 
:
ÀÀ 
$str
ÀÀ %
,
ÀÀ% &
column
ÁÁ 
:
ÁÁ 
$str
ÁÁ '
)
ÁÁ' (
;
ÁÁ( )
migrationBuilder
ÃÃ 
.
ÃÃ 
CreateIndex
ÃÃ (
(
ÃÃ( )
name
ÄÄ 
:
ÄÄ 
$str
ÄÄ 1
,
ÄÄ1 2
table
ÅÅ 
:
ÅÅ 
$str
ÅÅ %
,
ÅÅ% &
column
ÆÆ 
:
ÆÆ 
$str
ÆÆ #
)
ÆÆ# $
;
ÆÆ$ %
migrationBuilder
ÈÈ 
.
ÈÈ 
CreateIndex
ÈÈ (
(
ÈÈ( )
name
ÉÉ 
:
ÉÉ 
$str
ÉÉ .
,
ÉÉ. /
table
ÊÊ 
:
ÊÊ 
$str
ÊÊ %
,
ÊÊ% &
column
ËË 
:
ËË 
$str
ËË  
)
ËË  !
;
ËË! "
migrationBuilder
ÍÍ 
.
ÍÍ 
CreateIndex
ÍÍ (
(
ÍÍ( )
name
ÎÎ 
:
ÎÎ 
$str
ÎÎ 9
,
ÎÎ9 :
table
ÏÏ 
:
ÏÏ 
$str
ÏÏ '
,
ÏÏ' (
column
ĞĞ 
:
ĞĞ 
$str
ĞĞ )
)
ĞĞ) *
;
ĞĞ* +
migrationBuilder
ÒÒ 
.
ÒÒ 
CreateIndex
ÒÒ (
(
ÒÒ( )
name
ÓÓ 
:
ÓÓ 
$str
ÓÓ 2
,
ÓÓ2 3
table
ÔÔ 
:
ÔÔ 
$str
ÔÔ '
,
ÔÔ' (
column
ÕÕ 
:
ÕÕ 
$str
ÕÕ "
)
ÕÕ" #
;
ÕÕ# $
migrationBuilder
×× 
.
×× 
CreateIndex
×× (
(
××( )
name
ØØ 
:
ØØ 
$str
ØØ 3
,
ØØ3 4
table
ÙÙ 
:
ÙÙ 
$str
ÙÙ '
,
ÙÙ' (
column
ÚÚ 
:
ÚÚ 
$str
ÚÚ #
)
ÚÚ# $
;
ÚÚ$ %
migrationBuilder
ÜÜ 
.
ÜÜ 
CreateIndex
ÜÜ (
(
ÜÜ( )
name
İİ 
:
İİ 
$str
İİ *
,
İİ* +
table
ŞŞ 
:
ŞŞ 
$str
ŞŞ !
,
ŞŞ! "
column
ßß 
:
ßß 
$str
ßß  
)
ßß  !
;
ßß! "
}
àà 	
	protected
ãã 
override
ãã 
void
ãã 
Down
ãã  $
(
ãã$ %
MigrationBuilder
ãã% 5
migrationBuilder
ãã6 F
)
ããF G
{
ää 	
migrationBuilder
åå 
.
åå 
	DropTable
åå &
(
åå& '
name
ææ 
:
ææ 
$str
ææ (
)
ææ( )
;
ææ) *
migrationBuilder
èè 
.
èè 
	DropTable
èè &
(
èè& '
name
éé 
:
éé 
$str
éé (
)
éé( )
;
éé) *
migrationBuilder
ëë 
.
ëë 
	DropTable
ëë &
(
ëë& '
name
ìì 
:
ìì 
$str
ìì (
)
ìì( )
;
ìì) *
migrationBuilder
îî 
.
îî 
	DropTable
îî &
(
îî& '
name
ïï 
:
ïï 
$str
ïï '
)
ïï' (
;
ïï( )
migrationBuilder
ññ 
.
ññ 
	DropTable
ññ &
(
ññ& '
name
òò 
:
òò 
$str
òò (
)
òò( )
;
òò) *
migrationBuilder
ôô 
.
ôô 
	DropTable
ôô &
(
ôô& '
name
õõ 
:
õõ 
$str
õõ #
)
õõ# $
;
õõ$ %
migrationBuilder
÷÷ 
.
÷÷ 
	DropTable
÷÷ &
(
÷÷& '
name
øø 
:
øø 
$str
øø %
)
øø% &
;
øø& '
migrationBuilder
úú 
.
úú 
	DropTable
úú &
(
úú& '
name
ûû 
:
ûû 
$str
ûû %
)
ûû% &
;
ûû& '
migrationBuilder
ıı 
.
ıı 
	DropTable
ıı &
(
ıı& '
name
şş 
:
şş 
$str
şş $
)
şş$ %
;
şş% &
migrationBuilder
€€ 
.
€€ 
	DropTable
€€ &
(
€€& '
name
 
:
 
$str
 $
)
$ %
;
% &
migrationBuilder
ƒƒ 
.
ƒƒ 
	DropTable
ƒƒ &
(
ƒƒ& '
name
„„ 
:
„„ 
$str
„„ &
)
„„& '
;
„„' (
migrationBuilder
†† 
.
†† 
	DropTable
†† &
(
††& '
name
‡‡ 
:
‡‡ 
$str
‡‡ &
)
‡‡& '
;
‡‡' (
migrationBuilder
‰‰ 
.
‰‰ 
	DropTable
‰‰ &
(
‰‰& '
name
ŠŠ 
:
ŠŠ 
$str
ŠŠ #
)
ŠŠ# $
;
ŠŠ$ %
migrationBuilder
ŒŒ 
.
ŒŒ 
	DropTable
ŒŒ &
(
ŒŒ& '
name
 
:
 
$str
 #
)
# $
;
$ %
migrationBuilder
 
.
 
	DropTable
 &
(
& '
name
 
:
 
$str
 $
)
$ %
;
% &
migrationBuilder
’’ 
.
’’ 
	DropTable
’’ &
(
’’& '
name
““ 
:
““ 
$str
““ &
)
““& '
;
““' (
migrationBuilder
•• 
.
•• 
	DropTable
•• &
(
••& '
name
–– 
:
–– 
$str
––  
)
––  !
;
––! "
migrationBuilder
˜˜ 
.
˜˜ 
	DropTable
˜˜ &
(
˜˜& '
name
™™ 
:
™™ 
$str
™™ 
)
™™  
;
™™  !
migrationBuilder
›› 
.
›› 
	DropTable
›› &
(
››& '
name
œœ 
:
œœ 
$str
œœ "
)
œœ" #
;
œœ# $
migrationBuilder
 
.
 
	DropTable
 &
(
& '
name
ŸŸ 
:
ŸŸ 
$str
ŸŸ #
)
ŸŸ# $
;
ŸŸ$ %
migrationBuilder
¡¡ 
.
¡¡ 
	DropTable
¡¡ &
(
¡¡& '
name
¢¢ 
:
¢¢ 
$str
¢¢ 
)
¢¢ 
;
¢¢  
migrationBuilder
¤¤ 
.
¤¤ 
	DropTable
¤¤ &
(
¤¤& '
name
¥¥ 
:
¥¥ 
$str
¥¥ #
)
¥¥# $
;
¥¥$ %
}
¦¦ 	
}
§§ 
}¨¨ ™
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
} ‰
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
} Â
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
 º
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
}		 Ö
€D:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.DataAccess\IRepository\ISectionDetailsVersionRepository.cs
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
} î
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
} „
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
} ³
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
 ƒ	
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
} ¨
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
} Ö
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
}		 ô
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
} Ó
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
 «

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
} Ø
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
 Ü	
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
 š
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
} Ï
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
 Ğ0
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