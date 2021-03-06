﻿using UnityEngine;

namespace QonversionUnity
{
    internal class QonversionAndroidHandler : AndroidJavaProxy, IQonversionResultHandler
    {
        private const string QONVERSION_WRAPPER_INTERFACE_PATH = "com.qonversion.unitywrapper.IQonversionResultHandler";

        public InitDelegate InitComplete;

        public QonversionAndroidHandler(InitDelegate onInitComplete) : base(QONVERSION_WRAPPER_INTERFACE_PATH)
        {
            InitComplete = onInitComplete;
        }

        public void onSuccessInit(string uid)
        {
            InitComplete?.Invoke();
        }

        public void onErrorInit(string errorMessage)
        {
            Debug.LogError(string.Format("[Qonversion] onErrorInit Error: {0}", errorMessage));
        }
    }
}