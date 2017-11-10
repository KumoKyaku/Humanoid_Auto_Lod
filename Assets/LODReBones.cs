using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LODGroup))]
public class LODReBones : MonoBehaviour {

    LODGroup lod;
	// Use this for initialization
	void Start () {
        lod = GetComponent<LODGroup>();
        if (lod)
        {
            var res = lod.GetLODs();
            if (res.Length > 0)
            {
                for (int i = 0; i < res[0].renderers.Length; i++)
                {
                    var smr = res[0].renderers[i] as SkinnedMeshRenderer;
                    if (smr)
                    {
                        for (int j = 1; j < res.Length; j++)
                        {
                            var lodsmr = res[j].renderers[i] as SkinnedMeshRenderer;
                            if (lodsmr)
                            {
                                lodsmr.rootBone = smr.rootBone;
                                //lodsmr.bones = smr.bones;
                                for (int k = 0; k < lodsmr.bones.Length; k++)
                                {
                                    var targetbone = smr.bones.FirstOrDefault(
                                        tar => tar.name == lodsmr.bones[k].name);
                                    //Transform targetbone = null;
                                    //float weight = 0f;
                                    //for (int l = 0; l < smr.bones.Length; l++)
                                    //{
                                    //    if (smr.bones[l].name == lodsmr.bones[k].name)
                                    //    {
                                    //        targetbone = smr.bones[l];
                                    //        weight = smr.GetBlendShapeWeight(l);
                                    //    }
                                    //}
                                    lodsmr.bones[k] = targetbone;
                                    //lodsmr.SetBlendShapeWeight(k, weight);
                                }

                                //lodsmr.enabled = false;
                                //lodsmr.enabled = true;
                            }
                        }
                    }
                }
            }

        }
	}
}
