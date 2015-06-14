Shader "Custom/ShaderHighlightObj" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
}
SubShader { 
 LOD 100
 Tags { "RenderType"="Opaque" "Queue"="Background"}
		ZWrite On


 // Stats for Vertex shader:
 //       d3d11 : 4 math
 //    d3d11_9x : 4 math
 //        d3d9 : 4 math
 // Stats for Fragment shader:
 //        d3d9 : 3 math
 Pass {
  Tags { "RenderType"="Opaque" }
  GpuProgramID 29821
Program "vp" {
SubProgram "d3d9 " {
// Stats: 4 math
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
"vs_2_0
dcl_position v0
dp4 oPos.x, c0, v0
dp4 oPos.y, c1, v0
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0

"
}
SubProgram "d3d11 " {
// Stats: 4 math
Bind "vertex" Vertex
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "UnityPerDraw" 0
"vs_4_0
root12:aaabaaaa
eefiecedijhpljdppnfhjnjaadaickkmhicpkjbcabaaaaaaheabaaaaadaaaaaa
cmaaaaaagaaaaaaajeaaaaaaejfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafaepfdejfeejepeoaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafdeieefcniaaaaaaeaaaabaa
dgaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
// Stats: 4 math
Bind "vertex" Vertex
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "UnityPerDraw" 0
"vs_4_0_level_9_1
root12:aaabaaaa
eefieceddggiiplcpkoeljnckhkjahapknjdfpkhabaaaaaadeacaaaaaeaaaaaa
daaaaaaaomaaaaaammabaaaaaaacaaaaebgpgodjleaaaaaaleaaaaaaaaacpopp
iaaaaaaadeaaaaaaabaaceaaaaaadaaaaaaadaaaaaaaceaaabaadaaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjaafaaaaad
aaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcniaaaaaaeaaaabaadgaaaaaafjaaaaae
egiocaaaaaaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadoaaaaabejfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafaepfdejfeejepeoaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa"
}
}
Program "fp" {
SubProgram "d3d9 " {
// Stats: 3 math
Vector 0 [_Color]
"ps_2_0
def c1, 1, 0, 0, 0
mov_pp r0.xyz, c0
mov_pp r0.w, c1.x
mov_pp oC0, r0

"
}
SubProgram "d3d11 " {
ConstBuffer "$Globals" 112
Vector 96 [_Color]
BindCB  "$Globals" 0
"ps_4_0
root12:aaabaaaa
eefiecedhckpjkeeokokjfepldipgkbjedohjchiabaaaaaapaaaaaaaadaaaaaa
cmaaaaaagaaaaaaajeaaaaaaejfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfeaaaaaaeaaaaaaa
bfaaaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaagfaaaaadpccabaaaaaaaaaaa
dgaaaaaghccabaaaaaaaaaaaegiccaaaaaaaaaaaagaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "d3d11_9x " {
ConstBuffer "$Globals" 112
Vector 96 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
root12:aaabaaaa
eefiecedoljmhdfebgahkehnofpejicnmhngenfpabaaaaaahaabaaaaaeaaaaaa
daaaaaaakmaaaaaaaiabaaaadmabaaaaebgpgodjheaaaaaaheaaaaaaaaacpppp
eeaaaaaadaaaaaaaabaaceaaaaaadaaaaaaadaaaaaaaceaaaaaadaaaaaaaagaa
abaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaiadpaaaaaaaaaaaaaaaa
aaaaaaaaabaaaaacaaaachiaaaaaoekaabaaaaacaaaaciiaabaaaakaabaaaaac
aaaicpiaaaaaoeiappppaaaafdeieefcfeaaaaaaeaaaaaaabfaaaaaafjaaaaae
egiocaaaaaaaaaaaahaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaaghccabaaa
aaaaaaaaegiccaaaaaaaaaaaagaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaiadpdoaaaaabejfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaaepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
}
